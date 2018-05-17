using System.Collections.Generic;

namespace CfSharp
{
    public class LaunchConfiguration : IEntity, IEntityValue
    {
        public const string CFType = "AWS::AutoScaling::LaunchConfiguration";

        private readonly string _name;

        public string Type => CFType;

        public LaunchConfigurationProperties Properties { get; set; } = new LaunchConfigurationProperties();
        
        public MetaData Metadata { get; set; } = new MetaData();

        public LaunchConfiguration()
        {

        }

        public LaunchConfiguration(Stack stack, string name)
        {
            _name = name;
            stack.Resources.Add(name, this);
        }

        public LaunchConfiguration InstanceMonitoring(bool instanceMonitoring)
        {
            Properties.InstanceMonitoring = instanceMonitoring;
            return this;
        }

        public LaunchConfiguration InstanceType(IEntityValue instanceType) => InstanceType(instanceType.GetValue());

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

        public LaunchConfiguration ImageId(IEntityValue imageId) => ImageId(imageId.GetValue());

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

        public LaunchConfiguration SecurityGroups(IEntityValue securityGroup) => SecurityGroups(securityGroup.GetValue());

        public LaunchConfiguration UserData(string userData) => UserData((object)userData);

        public LaunchConfiguration KeyName(IEntityValue keyName) => KeyName(keyName.GetValue());

        public LaunchConfiguration KeyName(string keyName) => KeyName((object)keyName);

        public LaunchConfiguration KeyName(object keyName)
        {
            Properties.KeyName = keyName;
            return this;
        }

        public LaunchConfiguration BlockDeviceMapping(LaunchConfigurationBlockDeviceMapping mapping)
        {
            Properties.BlockDeviceMappings.Add(mapping);
            return this;
        }

        public LaunchConfiguration UserData(object userData)
        {
            Properties.UserData = userData;
            return this;
        }

        public string GetName()
        {
            return _name;
        }

        public object GetValue()
        {
            return new EntityReference(_name);
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

            public List<LaunchConfigurationBlockDeviceMapping> BlockDeviceMappings { get; set; } = new List<LaunchConfigurationBlockDeviceMapping>();
        }

        public class LaunchConfigurationBlockDeviceMapping
        {
            public object DeviceName { get; set; }
            public Ebs Ebs { get; set; } = new Ebs();
            public object NoDevice { get; set; }
            public object VirtualName { get; set; }
        }

        public class Ebs
        {
            public object VolumeSize { get; set; }

            public object VolumeType { get; set; }
        }

        

    }
}
