using System.Collections.Generic;

namespace CfSharp.AutoScaling
{
    public class LaunchConfiguration
    {
        public string Type { get; set; } = "AWS::AutoScaling::LaunchConfiguration";

        public LaunchConfigurationProperties Properties { get; set; } = new LaunchConfigurationProperties();

        public LaunchConfiguration InstanceMonitoring(bool instanceMonitoring)
        {
            Properties.InstanceMonitoring = instanceMonitoring;
            return this;
        }

        public LaunchConfiguration InstanceType(IEntityValue instanceType) => InstanceType(instanceType.Value);

        public LaunchConfiguration InstanceType(string instanceType) => InstanceType((object)instanceType);

        public LaunchConfiguration InstanceType(object instanceType)
        {
            Properties.InstanceType = instanceType;
            return this;
        }

        public LaunchConfiguration IamInstanceProfile(string iamInstanceProfile)
        {
            Properties.IamInstanceProfile = iamInstanceProfile;
            return this;
        }

        public LaunchConfiguration ImageId(IEntityValue imageId) => ImageId(imageId.Value);

        public LaunchConfiguration ImageId(object imageId)
        {
            Properties.ImageId = imageId;
            return this;
        }

        public LaunchConfiguration SecurityGroups(string securityGroup) => SecurityGroups((object)securityGroup);

        public LaunchConfiguration SecurityGroups(object securityGroup)
        {
            Properties.SecurityGroups.Add(securityGroup);
            return this;
        }

        public LaunchConfiguration SecurityGroups(IEntityValue securityGroup) => SecurityGroups(securityGroup.Value);

        public LaunchConfiguration UserData(string userData) => UserData((object)userData);

        public LaunchConfiguration KeyName(IEntityValue keyName) => KeyName(keyName.Value);

        public LaunchConfiguration KeyName(string keyName) => KeyName((object)keyName);

        public LaunchConfiguration KeyName(object keyName)
        {
            Properties.KeyName = keyName;
            return this;
        }

        public LaunchConfiguration UserData(object userData)
        {
            Properties.UserData = userData;
            return this;
        }

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
