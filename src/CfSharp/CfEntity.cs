using System.Collections.Generic;
using Newtonsoft.Json;

namespace CfSharp
{
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
