using System.Collections.Generic;

namespace CfSharp.AutoScaling
{
    public class LaunchConfiguration
    {
        public string Type { get; set; } = "AWS::AutoScaling::LaunchConfiguration";

        public LaunchConfigurationProperties Properties { get; set; } = new LaunchConfigurationProperties();

        public class LaunchConfigurationProperties
        {
            public bool AssociatePublicIpAddress { get; set; }

            public object ClassicLinkVPCId { get; set; }

            public bool EbsOptimized { get; set; }

            public object IamInstanceProfile { get; set; }

            public object ImageId { get; set; }

            public object InstanceId { get; set; }

            public bool InstanceMonitoring { get; set; }

            public object InstanceType { get; set; }

            public object KernelId { get; set; }

            public object KeyName { get; set; }

            public object PlacementTenancy { get; set; }

            public object RamDiskId { get; set; }

            public List<object> SecurityGroups { get; set; } = new List<object>();

            public object SpotPrice { get; set; }

            public object UserData { get; set; }

            public List<object> ClassicLinkVPCSecurityGroups { get; set; }

            //"BlockDeviceMappings" : [BlockDeviceMapping, ... ],
        }
    }
}
