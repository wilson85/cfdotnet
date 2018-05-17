using System;

namespace CfSharp
{
    public class RecordSet
    {
        public const string CFType = "AWS::Route53::RecordSet";
        public string Type = CFType;

        public RecordSetProperties Properties { get; set; } = new RecordSetProperties();

        public RecordSet HostedZoneName(object hostedZoneName)
        {
            Properties.HostedZoneName = hostedZoneName;
            return this;
        }

        public RecordSet Name(object name)
        {
            Properties.Name = name;
            return this;
        }

        public RecordSet RecordSetType(object type)
        {
            Properties.Type = type;
            return this;
        }

        public RecordSet AliasTarget(Action<RecordSetAliasTarget> aliasConfig)
        {
            aliasConfig(Properties.AliasTarget);

            return this;
        }

        public class RecordSetProperties
        {
            public object HostedZoneName { get; set; }

            public object Name { get; set; }

            public object Type { get; set; }

            public RecordSetAliasTarget AliasTarget { get; set; } = new RecordSetAliasTarget();
        }

        public class RecordSetAliasTarget
        {
            public object HostedZoneId { get; set; }

            public object DNSName { get; set; }
        }
    }
}
