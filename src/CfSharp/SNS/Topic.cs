using System;
using System.Collections.Generic;

namespace CfSharp
{
    public class Topic : IEntity
    {
        public const string CFType = "AWS::SNS::Topic";
        private readonly string _name;
        private readonly Stack _stack;

        public string Type => CFType;

        public Topic(Stack stack, string name)
        {
            _name = name;
            _stack = stack;
        }

        public TopicProperties Properties { get; set; } = new TopicProperties();

        public string GetName() => _name;

        public class TopicProperties
        {
            public List<SnsSubscription> Subscription { get; set; }
        }

        public class SnsSubscription
        {
            public object Endpoint { get; set; }

            public object Protocol { get; set; }
        }
    }
}
