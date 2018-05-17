using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CfSharp
{

    public class StackParameterValue
    {
        public string Ref { get; set; }

        public StackParameterValue(StackParameter param)
        {
            Ref = param.Name;
        }
    }
}
