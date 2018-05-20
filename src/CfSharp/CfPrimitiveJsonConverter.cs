using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CfSharp
{
    public class CfPrimitiveJsonConverter : JsonConverter
    {
        private static Dictionary<string, Type> KnownTypes = new Dictionary<string, Type>()
        {
            {"Ref", typeof(EntityReference) },
            {"Fn::Join" , typeof(FnJoin) },
            {"Fn::GetAtt" , typeof(FnGetAtt) }
        };

        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(object))
            {
                return true;
            }

            if (objectType == typeof(List<object>))
            {
                return true;
            }



            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            //serializer.Converters.Add(this);

            JToken token = serializer.Deserialize<JToken>(reader);

            object toObjectOrRef(JToken tk)
            {
                object obj;

                if (tk.Type == JTokenType.Object)
                {
                    var props = tk.ToObject<JObject>().Properties();

                    if (!props.Any() || props.Count() > 1)
                    {
                        throw new ApplicationException("Functions should only have 1 property");
                    }

                    // is a reference to something
                    Type knownType = KnownTypes[props.First().Name];

                    obj = tk.ToObject(knownType, serializer);
                }
                else
                {
                    obj = tk.ToObject(typeof(object), serializer);
                }

                return obj;
            }
            

            switch (token.Type)
            {
                case JTokenType.Object:
                    var objectOrRef = toObjectOrRef(token);
                    object ob = Activator.CreateInstance(objectType);

                    switch(objectType)
                    {
                            case object o:
                            return objectOrRef;
                                break;
                    }
                    ob.GetType().GetMethod("Add").Invoke(ob, new[] { objectOrRef });
                    return ob;
                case JTokenType.Array:
                    return token.ToObject<JToken>().Select(toObjectOrRef).ToList();
                case JTokenType.String:
                    return token.ToString();
                case JTokenType.Null:
                case JTokenType.Undefined:
                default:
                    return Activator.CreateInstance(objectType);
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
