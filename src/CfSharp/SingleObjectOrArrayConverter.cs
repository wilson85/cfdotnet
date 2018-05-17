using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CfSharp
{
    public class SingleObjectOrArrayConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = serializer.Deserialize<JToken>(reader);

            object toObjectOrRef(JToken tk)
            {
                object obj;

                if (tk.Type == JTokenType.Object && tk["Ref"] != null)
                {
                    // is a reference to something

                    obj = tk.ToObject<EntityReference>(serializer);
                }
                else
                {
                    obj = tk.ToObject(objectType.GetGenericArguments().Single(), serializer);
                }

                return obj;
            }

            switch (token.Type)
            {
                case JTokenType.Object:
                    var objectOrRef = toObjectOrRef(token);
                    object ob = Activator.CreateInstance(objectType);
                    ob.GetType().GetMethod("Add").Invoke(ob, new[] { objectOrRef });
                    return ob;
                case JTokenType.Array:
                    return token.ToObject<JToken>().Select(toObjectOrRef).ToList();
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
