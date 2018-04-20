namespace CfSharp.AutoScaling
{
    public class LifecycleHook
    {
        public string Type { get; set; } = "AWS::AutoScaling::LifecycleHook";

        public LifecycleHookProperties Properties { get; set; } = new LifecycleHookProperties();

        public LifecycleHook AutoScalingGroupName(IEntityValue autoScalingGroupName) => AutoScalingGroupName(autoScalingGroupName.GetValue());

        public LifecycleHook AutoScalingGroupName(object autoScalingGroupName)
        {
            Properties.AutoScalingGroupName = autoScalingGroupName;
            return this;
        }

        public LifecycleHook AutoScalingGroupName(string autoScalingGroupName) => AutoScalingGroupName((object)autoScalingGroupName);

        public LifecycleHook DefaultResult(string defaultResult)
        {
            Properties.DefaultResult = defaultResult;
            return this;
        }

        public LifecycleHook NotificationTargetArn(object notificationArn)
        {
            Properties.NotificationTargetARN = notificationArn;
            return this;
        }

        public LifecycleHook HeartbeatTimeout(object timeout)
        {
            Properties.HeartbeatTimeout = timeout;
            return this;
        }

        public LifecycleHook LifecycleTransition(object transition)
        {
            Properties.LifecycleTransition = transition;
            return this;
        }

        public LifecycleHook RoleArn(object roleArn)
        {
            Properties.RoleARN = roleArn;
            return this;
        }

        public class LifecycleHookProperties
        {
            public object AutoScalingGroupName { get; set; }

            public string DefaultResult { get; set; }

            public object NotificationTargetARN { get; set; }

            public object HeartbeatTimeout { get; set; }

            public object LifecycleTransition { get; set; }

            public object RoleARN { get; set; }
        }
    }
}
