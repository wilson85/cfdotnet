using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CfSharp
{
    public interface IEntity
    {
        string Type { get; }

        string GetName();
    }

    public class LoadBalancerEntity : IEntity
    {
        public LoadBalancerEntity(string name, Stack stack)
        {
            _stack = stack;
            _stack.Resources.Add(name, this);
            _name = name;
        }

        public string Type { get; } = "AWS::ElasticLoadBalancingV2::LoadBalancer";

        public LoadBalancerProperties Properties { get; } = new LoadBalancerProperties();

        public LoadBalancerEntity Tags(string key, IEntityValue value)
            => Tags(key, value.Value);

        public LoadBalancerEntity Tags(string key, object value)
        {
            this.Properties.Tags.Add(new Tag(key, value));

            return this;
        }


        private Stack _stack;
        private readonly string _name;

        /// <summary>
        /// Sets idle_timeout.timeout_seconds
        /// </summary>
        public LoadBalancerEntity IdleTimeoutSeconds(int seconds)
        {
            this.Properties.LoadBalancerAttributes.Add(new KeyValuePair("idle_timeout.timeout_seconds", new StringEntityValue(seconds.ToString())));

            return this;
        }

        public LoadBalancerEntity Listener(string name, Action<ListenerEntity> config)
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

        public IEntityValue Scheme { get; set; }

        public List<IEntityValue> Subnets { get; set; } = new List<IEntityValue>();

    }

    public class EntityProperties : List<KeyValuePair>
    {

    }

    public class StringEntityValue : IEntityValue
    {
        public StringEntityValue(string value)
        {
            Value = value;
        }

        public object Value
        {
            get; set;
        }
    }
}
