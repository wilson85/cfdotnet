namespace CfSharp
{
    public class RecordSet
    {
        public string Type { get; } = "AWS::Route53::RecordSet";

        public class RecordSetProperties
        {
            public object HostedZoneName { get; set; }

            public object Name { get; set; }

            public string Type { get; set; }

            public RecordSetAliasTarget AliasTarget { get; set; } = new RecordSetAliasTarget(); 
        }

        public class RecordSetAliasTarget
        {
            public object HostedZoneId { get; set; }

            public object DNSName { get; set; }
        }
    }
}
