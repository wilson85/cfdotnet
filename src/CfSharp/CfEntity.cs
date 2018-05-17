using System.Collections.Generic;
using JsonSubTypes;
using Newtonsoft.Json;

namespace CfSharp
{
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(AutoScalingGroup), AutoScalingGroup.CFType)]
    [JsonSubtypes.KnownSubType(typeof(LaunchConfiguration), LaunchConfiguration.CFType)]
    [JsonSubtypes.KnownSubType(typeof(LifecycleHook), LifecycleHook.CFType)]
    [JsonSubtypes.KnownSubType(typeof(Alarm), Alarm.CFType)]
    [JsonSubtypes.KnownSubType(typeof(Listener), Listener.CFType)]
    [JsonSubtypes.KnownSubType(typeof(ListenerRule), ListenerRule.CFType)]
    [JsonSubtypes.KnownSubType(typeof(LoadBalancer), LoadBalancer.CFType)]
    [JsonSubtypes.KnownSubType(typeof(TargetGroup), TargetGroup.CFTtype)]
    [JsonSubtypes.KnownSubType(typeof(RecordSet), RecordSet.CFType)]
    [JsonSubtypes.KnownSubType(typeof(Topic), Topic.CFType)]
    public interface IEntity
    {
        string Type { get; }

        string GetName();
    }

 

    public class EntityProperties : List<KeyValuePair>
    {

    }

    public class StringEntityValue : IEntityValue
    {
        private readonly string _value;

        public StringEntityValue(string value)
        {
            _value = value;
        }

        public object GetValue()
        {
            return _value;
        }
    }
}
