using System;
using System.Collections.Generic;
using System.Linq;

namespace CfSharp
{
    public class AutoScalingGroup : IEntity
    {
        private readonly Stack _stack;
        private readonly string _name;

        public AutoScalingGroup(Stack stack, string name)
        {
            _stack = stack;
            _name = name;

            _stack.Resources.Add(name, this);
        }

        public string Type { get; } = "AWS::AutoScaling::AutoScalingGroup";

        public AutoScalingGroupProperties Properties { get; } = new AutoScalingGroupProperties();

        public AutoScalingGroup TargetGroupArns(params IEntityValue[] targetGroupArns)
        {
            foreach (var item in targetGroupArns)
            {
                Properties.TargetGroupARNs.Add(item.GetValue());
            }

            return this;
        }

        public AutoScalingGroup MaxSize(StackParameter maxCapacityParam)
        {
            Properties.MaxSize = maxCapacityParam.GetValue();

            return this;
        }

        public AutoScalingGroup AvailavilityZones(params string[] availabilityZone)
        {
            foreach (var item in availabilityZone)
            {
                Properties.AvailabilityZones.Add(item);
            }

            return this;
        }

        public AutoScalingGroup Cooldown(int cooldown)
        {
            this.Properties.Cooldown = cooldown.ToString();

            return this;
        }

        public AutoScalingGroup HealthCheckGracePeriod(int period)
        {
            this.Properties.HealthCheckGracePeriod = period;

            return this;
        }

        public AutoScalingGroup HealthCheckType(HealthCheckType type)
        {
            this.Properties.HealthCheckType = Enum.GetName(typeof(HealthCheckType), type);

            return this;
        }

        public AutoScalingGroup MinSize(IEntityValue minCapacityParam)
        {
            this.Properties.MinSize = minCapacityParam.GetValue();

            return this;
        }

        public AutoScalingGroup Tags(string key, IEntityValue value, bool propergateAtLaunch)
            => Tags(key, value.GetValue(), propergateAtLaunch);

        public AutoScalingGroup Tags(string key, object value, bool propergateAtLaunch)
        {
            Properties.Tags.Add(new AutoScalingGroupTag(key, value, propergateAtLaunch));

            return this;
        }

        public AutoScalingGroup DesiredCapacity(IEntityValue desiredCapacity)
        {
            this.Properties.DesiredCapacity = desiredCapacity.GetValue();

            return this;
        }

        public AutoScalingGroup Notifications(object topicArn, params NotificationTypes[] notifications)
        {
            Properties.NotificationConfigurations.Add(new NotificationConfiguration()
            {
                NotificationTypes = notifications.Select(x => "autoscaling:" + Enum.GetName(typeof(NotificationTypes), x)).Cast<object>().ToList(),
                TopicARN = topicArn
            });

            return this;
        }

        public AutoScalingGroup VPCZoneIdentifier(string subnet)
        {
            Properties.VPCZoneIdentifier.Add(subnet);

            return this;
        }

        public AutoScalingGroup LaunchConfigurationName(string launchConfigurationName) => LaunchConfigurationName((object)launchConfigurationName);

        public AutoScalingGroup LaunchConfigurationName(object launchConfigurationName)
        {
            Properties.LaunchConfigurationName = launchConfigurationName;
            return this;
        }

        public AutoScalingGroup LaunchConfigurationName(IEntityValue launchConfigurationName) 
            => LaunchConfigurationName(launchConfigurationName.GetValue());

        public string GetName()
        {
            return _name;
        }
    }

    public enum HealthCheckType
    {
        EC2
    }

    public class AutoScalingGroupProperties
    {
        public List<object> TargetGroupARNs { get; set; } = new List<object>();

        public object MaxSize { get; set; }

        public List<object> AvailabilityZones { get; set; } = new List<object>();

        public object Cooldown { get; set; }

        public object DesiredCapacity { get; set; }

        public object MinSize { get; set; }

        public object HealthCheckGracePeriod { get; set; }

        public object HealthCheckType { get; set; }

        public List<AutoScalingGroupTag> Tags { get; set; } = new List<AutoScalingGroupTag>();

        public List<object> VPCZoneIdentifier { get; set; } = new List<object>();

        public object LaunchConfigurationName { get; set; }

        public List<NotificationConfiguration> NotificationConfigurations { get; set; } = new List<NotificationConfiguration>();
    }

    public class AutoScalingGroupTag : Tag
    {
        public AutoScalingGroupTag(string key, object value, bool propagateAtLaunch)
            : base(key, value)
        {
            PropagateAtLaunch = propagateAtLaunch;
        }


        public bool PropagateAtLaunch { get; set; }
    }

    public class NotificationConfiguration
    {
        public List<object> NotificationTypes { get; set; }

        public object TopicARN { get; set; }
    }

    public enum NotificationTypes
    {
        EC2_INSTANCE_LAUNCH,
        EC2_INSTANCE_LAUNCH_ERROR,
        EC2_INSTANCE_TERMINATE,
        EC2_INSTANCE_TERMINATE_ERROR,
        TEST_NOTIFICATION
    }
}
