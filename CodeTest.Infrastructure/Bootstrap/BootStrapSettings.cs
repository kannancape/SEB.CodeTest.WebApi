using System;
using System.Collections.Generic;

namespace CodeTest.Infrastructure.Bootstrap
{
    public class BootStrapSettings
    {
        public List<DepedencyOverride> DependencyOverrides { get; set; }
        public bool RunVerifyOnDone { get; set; }
        public BootStrapSettings()
        {
            DependencyOverrides = new List<DepedencyOverride>();
            RunVerifyOnDone = true;
        }
        public class DepedencyOverride
        {
            public DepedencyOverride()
            {

            }
            public DepedencyOverride(Type type, object instance)
            {
                Type = type;
                TypeInstance = instance;
            }
            public Type Type { get; set; }
            public object TypeInstance { get; set; }
        }
    }
}

