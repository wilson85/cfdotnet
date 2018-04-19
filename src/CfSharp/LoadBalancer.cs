using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CfSharp
{
    public class LoadBalancer : IEntity
    {
        public LoadBalancer(string name, Stack stack)
        {
            _stack = stack;
            _stack.Resources.Add(name, this);
            _name = name;
        }

        public string Type { get; } = "AWS::ElasticLoadBalancingV2::LoadBalancer";

        public LoadBalancerProperties Properties { get; } = new LoadBalancerProperties();

        public LoadBalancer Tags(string key, IEntityValue value)
            => Tags(key, value.Value);

        public LoadBalancer Tags(string key, object value)
        {
            this.Properties.Tags.Add(new Tag(key, value));

            return this;
        }

        public LoadBalancer Scheme(Scheme scheme)
        {
            Properties.Scheme = scheme.GetDescription();
            return this;
        }


        private Stack _stack;
        private readonly string _name;

        /// <summary>
        /// Sets idle_timeout.timeout_seconds
        /// </summary>
        public LoadBalancer IdleTimeoutSeconds(int seconds)
        {
            this.Properties.LoadBalancerAttributes.Add(new KeyValuePair("idle_timeout.timeout_seconds", new StringEntityValue(seconds.ToString())));

            return this;
        }

        public LoadBalancer Listener(string name, Action<ListenerEntity> config)
        {
            ListenerEntity listener = new ListenerEntity(_stack, name);

            config(listener);

            return this;
        }

        public string GetName()
        {
            return _name;
        }
    }

    public class LoadBalancerProperties
    {
        public EntityProperties LoadBalancerAttributes { get; set; } = new EntityProperties();

        public Tags Tags { get; set; } = new Tags();

        public List<IEntityValue> SecurityGroups { get; set; } = new List<IEntityValue>();
        
        public string Scheme { get; set; }

        public List<IEntityValue> Subnets { get; set; } = new List<IEntityValue>();

    }

    public enum Scheme {
        [Description("internet-facing")]
        InternetFacing
    }
}
