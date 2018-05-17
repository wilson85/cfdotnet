namespace CfSharp.EC2
{
    public class SecurityGroup : IEntity
    {
        public const string CFType = "AWS::EC2::SecurityGroup";
        private readonly Stack _stack;
        private readonly string _name;

        public string Type => CFType;

        public SecurityGroup(Stack stack, string name)
        {
            _stack = stack;
            _stack.Resources.Add(_name, this);
            _name = name;
        }

        public string GetName() => _name;

        public class SecurityGroupProperties
        {
            public object GroupName { get; set; }

            public object GroupDescription { get; set; }

            public SecurityGroupRule SecurityGroupIgress { get; set; }

            public SecurityGroupRule SecurityGroupEgress { get; set; }
        }

        public class SecurityGroupRule
        {
            public object CidrIp { get; set; }
            public object CidrIpv6 { get; set; }
            public object Description { get; set; }
            public object FromPort { get; set; }
            public object IpProtocol { get; set; }
            public object SourceSecurityGroupId { get; set; }
            public object SourceSecurityGroupName { get; set; }
            public object SourceSecurityGroupOwnerId { get; set; }
            public object ToPort { get; set; }
        }
    }
}
