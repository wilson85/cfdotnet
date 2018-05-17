using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CfSharp
{

    public class StackParameter : IEntityValue
    {
        public virtual string Type { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual int? MinValue { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual int? MaxValue { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Description { get; set; }

        public string ConstraintDescription { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Default { get; set; }

        public string AllowedPattern { get; set; }

        public List<string> AllowedValues { get; set; }

        [JsonIgnore]
        public virtual string Name { get; }

        public StackParameter(string name, string type)
        {
            Type = type;
            Name = name;
        }

        public object GetValue()
        {
            return new StackParameterValue(this);
        }
    }
}
