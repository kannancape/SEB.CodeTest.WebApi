using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using CodeTest.Domain.Commands;
using CodeTest.Domain.Repository.Implementation;
using CodeTest.Domain.Repository.Interface;
//using CodeTest.Domain.Repository.Implementation;
//using CodeTest.Domain.Repository.Interface;
using MediatR;
using MediatR.Pipeline;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using IsolationLevel = System.Transactions.IsolationLevel;

namespace CodeTest.Infrastructure.Bootstrap
{
    public static class Bootstrapper
    {
        private static Container _container;
        public static Scope BeginExeutionContextScope()
        {
            return SimpleInjector.Lifestyles.AsyncScopedLifestyle.BeginScope(_container);
        }

        public static object GetInstance(Type serviceType)
        {
            try
            {
                return _container.GetInstance(serviceType);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return null;
        }

        public static T GetInstance<T>() where T : class
        {
            return _container.GetInstance<T>();
        }

        public static Container CreateSimpleInjectorContainer(BootStrapSettings settings)
        {
            return CreateContainerAndRegisterDependencies(settings);
        }

        private static Container CreateContainerAndRegisterDependencies(BootStrapSettings settings)
        {
            try
            {
                CreateContainer();
                RegisterMediator();
                RegisterRepositories();
                RegisterOverrides(settings.DependencyOverrides);
                return _container;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void RegisterRepositories()
        {
            _container.Register<ICustomerRepository, CustomerRepository>();
        }


        private static void RegisterMediator()
        {
            var assemblies = GetMediatorAssemblies().ToArray();
            _container.Register<IMediator, Mediator>();
            _container.Register(typeof(IRequestHandler<,>), assemblies);
            _container.Register(() => new ServiceFactory(_container.GetInstance));
            RegisterHandlers(_container, typeof(INotificationHandler<>), assemblies);
            RegisterHandlers(_container, typeof(IRequestExceptionAction<,>), assemblies);

            RegisterHandlers(_container, typeof(IRequestExceptionHandler<,,>), assemblies);
            RegisterHandlers(_container, typeof(IRequestPreProcessor<>), assemblies);
            RegisterHandlers(_container, typeof(IRequestPostProcessor<,>), assemblies);

            _container.Collection.Register(typeof(IPipelineBehavior<,>), new[]{
                typeof(RequestExceptionProcessorBehavior<,>),
                typeof(RequestExceptionActionProcessorBehavior<,>),
                typeof(RequestPreProcessorBehavior<,>),
                typeof(RequestPostProcessorBehavior<,>)
            });
        }

        private static void RegisterOverrides(List<BootStrapSettings.DepedencyOverride> overrides)
        {
            if (overrides.Any())
            {
                _container.Options.AllowOverridingRegistrations = true;
                foreach (var dalOverride in overrides)
                {
                    _container.RegisterInstance(dalOverride.Type, dalOverride.TypeInstance);
                }
                _container.Options.AllowOverridingRegistrations = false;
            }
        }

        private static IEnumerable<Assembly> GetMediatorAssemblies()
        {
            yield return typeof(CreateTestCommand).GetTypeInfo().Assembly;
        }

        private static void RegisterHandlers(Container container, Type collectionType, Assembly[] assemblies)
        {
            var handlerTypes = container.GetTypesToRegister(collectionType, assemblies, new TypesToRegisterOptions
            {
                IncludeGenericTypeDefinitions = true,
                IncludeComposites = false,

            });
            container.Collection.Register(collectionType, handlerTypes);
        }

        private static void CreateContainer()
        {
            _container?.Dispose();
            _container = new Container();
            _container.Options.DefaultLifestyle = Lifestyle.Scoped;
            _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            _container.Options.PropertySelectionBehavior = new ImportPropertySelectionBehavior();
            _container.Options.AllowOverridingRegistrations = true;
        }
    }
}

