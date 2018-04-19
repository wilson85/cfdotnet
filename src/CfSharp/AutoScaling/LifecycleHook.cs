using System;
using System.Collections.Generic;
using System.Text;

namespace CfSharp.AutoScaling
{
    public class LifecycleHook
    {
        public string Type { get; set; } = "AWS::AutoScaling::LifecycleHook";
    }
}
