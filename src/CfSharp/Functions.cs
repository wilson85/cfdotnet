using System.Collections.Generic;
using Newtonsoft.Json;

namespace CfSharp
{
    public static class Functions
    {
        public static FnJoin Join(string delimiter, params object[] items)
        {
            List<object> newObjects = new List<object>(items.Length);

            foreach (var item in items)
            {
                if (item is IEntityValue val)
                {
                    newObjects.Add(val.GetValue());
                }
                else
                {
                    newObjects.Add(item);
                }
            }

            return new FnJoin(delimiter, newObjects.ToArray());
        }

        public static FnGetAtt GetAtt(IEntity resource, string attributeName)
        {
            return new FnGetAtt(resource.GetName(), attributeName);
        }

        public static FnBase64 Base64(object value)
        {
            return new FnBase64(value);
        }

    }

    public class FnBase64
    {
        public FnBase64(string str)
        {
            Value = str;
        }

        public FnBase64(object obj)
        {
            Value = obj;
        }

        [JsonProperty(PropertyName = "Fn::Base64")]
        public object Value { get; set; }
    }

    public class FnJoin
    {
        public FnJoin(string delimiter, params object[] values)
        {
            Array = new object[] { delimiter, values };
        }


        [JsonProperty(PropertyName = "Fn::Join")]
        public object Array { get; set; }
    }


    public class FnGetAtt
    {
        public FnGetAtt(params string[] strings)
        {
            Array = strings;
        }

        [JsonProperty(PropertyName = "Fn::GetAtt")]
        public string[] Array { get; set; }
    }
}
