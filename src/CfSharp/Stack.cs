using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CfSharp
{
    public class Stack
    {
        public Dictionary<string, IEntity> Resources { get; } = new Dictionary<string, IEntity>();

        public Dictionary<string, StackParameter> Parameters = new Dictionary<string, StackParameter>();

        /// <summary>
        /// This is a list of inbuilt parameters which we need available but we dont want to output into our json
        /// </summary>
        private readonly Dictionary<string, StackParameter> _pseudoParameters = new Dictionary<string, StackParameter>()
        {
            { "AWS::StackName", new StackParameter("AWS::StackName", "Pseudo") }
        };

        private readonly string _name;

        public Stack(string name)
        {
            _name = name;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings()
            {
                MaxDepth = 9999
            });
        }

        public Stack LoadBalancer(string name, Action<LoadBalancer> config)
        {
            LoadBalancer loadBalancer = new LoadBalancer(name, this);
            config(loadBalancer);
            return this;
        }

        public StackParameter Parameter(string name, string type, Action<StackParameter> config = null)
        {
            StackParameter parameter = new StackParameter(name, type);
            config?.Invoke(parameter);
            this.Parameters.Add(name, parameter);
            return parameter;
        }

        public StackParameter GetParameter(string name)
        {
            return Parameters[name] ?? _pseudoParameters[name];
        }

        public TargetGroup TargetGroup(string name)
        {
            // if exists return existing

            return new TargetGroup(name);
        }

        public AutoScalingGroup AutoScalingGroup(string name, Action<AutoScalingGroup> config)
        {
            AutoScalingGroup autoScalingGroup = new AutoScalingGroup(this, name);
            config(autoScalingGroup);
            return autoScalingGroup;
        }

        public Alarm Alarm(string name, Action<Alarm> config)
        {
            Alarm alarm = new Alarm(this, name);
            config(alarm);
            return alarm;
        }

        public Stack Configure(Action<Stack> config)
        {
            config(this);

            return this;
        }
    }

    public class StackParameter : IEntityValue
    {
        public virtual string Type { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual int? MinValue { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual int? MaxValue { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Description { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Default { get; set; }

        [JsonIgnore]
        public virtual object Value
        {
            get
            {
                return new StackParameterValue(this);
            }
        }

        [JsonIgnore]
        public virtual string Name { get; }

        public StackParameter(string name, string type)
        {
            Type = type;
            Name = name;
        }
    }

    public class StackParameterValue
    {
        public string Ref { get; set; }

        public StackParameterValue(StackParameter param)
        {
            Ref = param.Name;
        }
    }
}
