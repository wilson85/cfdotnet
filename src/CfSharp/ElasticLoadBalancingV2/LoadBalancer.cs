using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace CfSharp
{
    public class LoadBalancer : IEntity, IEntityValue
    {
        public string Type => CFType;
        public const string CFType = "AWS::ElasticLoadBalancingV2::LoadBalancer";

        public LoadBalancer()
        {

        }

        public LoadBalancer(string name, Stack stack)
        {
            _stack = stack;
            _stack.Resources.Add(name, this);
            _name = name;
        }


        public LoadBalancerProperties Properties { get; } = new LoadBalancerProperties();


        public LoadBalancer Tags(string key, IEntityValue value)
            => Tags(key, value.GetValue());

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

        public LoadBalancer Subnets(object subnet)
        {
            Properties.Subnets.Add(subnet);
            return this;
        }

        public LoadBalancer SecurityGroups(object securityGroup)
        {
            Properties.SecurityGroups.Add(securityGroup);

            return this;
        }


        private Stack _stack;
        private readonly string _name;

        /// <summary>
        /// Sets idle_timeout.timeout_seconds
        /// </summary>
        public LoadBalancer IdleTimeoutSeconds(int seconds)
        {
            this.Properties.LoadBalancerAttributes.Add(new KeyValuePair("idle_timeout.timeout_seconds", seconds.ToString()));

            return this;
        }

        public LoadBalancer Listener(string name, Action<Listener> config)
        {
            Listener listener = new Listener(_stack, name);

            config(listener);

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
    }

    public class LoadBalancerProperties
    {
        public EntityProperties LoadBalancerAttributes { get; set; } = new EntityProperties();

        public Tags Tags { get; set; } = new Tags();

        public List<object> SecurityGroups { get; set; } = new List<object>();
        
        public string Scheme { get; set; }

        [JsonConverter(typeof(CfPrimitiveJsonConverter))]
        public List<object> Subnets { get; set; } = new List<object>();

    }

    public enum Scheme {
        [Description("internet-facing")]
        InternetFacing
    }
}
