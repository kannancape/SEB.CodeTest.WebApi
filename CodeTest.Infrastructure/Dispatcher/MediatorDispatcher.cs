
using CodeTest.Domain.QueryBase;
using MediatR;
using CodeTest.Infrastructure.Bootstrap;
using System.Reflection;
using System.Threading.Tasks;
using System;

namespace CodeTest.Infrastructure.Dispatcher
{
	public class MediatorDispatcher
	{
        public static async Task<QueryResponse> ExecuteMediatorAsync<IRequest>(IRequest queryCommand)
        {
            ValidateArgument(queryCommand);
            var response = new QueryResponse();
            using (Bootstrapper.BeginExeutionContextScope())
            {
                try
                {
                    var _mediator = Bootstrapper.GetInstance<IMediator>();
                    var result = _mediator.Send(queryCommand);
                    response.Result = await result;
                }
                catch (TargetInvocationException exception)
                {
                    throw new Exception(exception.Message.ToString());
                }
                return response;
            }
        }

        private static void ValidateArgument<IRequest>(IRequest queryCommand)
        {
            if (queryCommand == null)
                throw new NotImplementedException();
        }
    }
}

