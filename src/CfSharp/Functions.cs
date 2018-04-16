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
                    newObjects.Add(val.Value);
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
