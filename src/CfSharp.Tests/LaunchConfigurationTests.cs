using System.IO;
using CfSharp.Tests.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace CfSharp.Tests
{
    public class LaunchConfigurationTests
    {
        [Fact]
        public void Test()
        {
            var stack = new Stack("test");

            var lc = new LaunchConfiguration(stack, "lc")
                .ImageId("123")
                .InstanceType("123");

            string json = JsonConvert.SerializeObject(lc);

            AwsSchema schema = LoadSchema();

            validateAgainstSchema(json, schema);
        }

        private void validateAgainstSchema(string json, AwsSchema schema)
        {
            JObject parsed = JObject.Parse(json);

            string type = parsed.Property("Type").Value.ToString();

            Resource resource = schema.ResourceType[type];

            Assert.True(resource != null, $"Schema does not contain resource : {type}");

            JToken properties = parsed.GetValue("Properties");

            foreach (var prop in resource.Properties)
            {
                JToken jsonProp = properties[prop.Key];

                switch (jsonProp.Type)
                {
                    case JTokenType.Object:
                        // TODO : possible ref or param
                        break;
                    case JTokenType.None:
                    case JTokenType.Null:
                        Assert.False(prop.Value.Required, $"Property {prop.Key} is required on {type}");
                        continue;
                    default:
                       
                        break;

                }

                if (prop.Value.PrimitiveType != null)
                {
                    Assert.Equal(prop.Value.PrimitiveType, jsonProp.Type.ToString());
                }
                else if (prop.Value.ItemType != null)
                {
                    // TODO : recursive check of the type on the property
                }
                else
                {

                }

            }


        }


        public AwsSchema LoadSchema()
        {
            using (var sr = File.OpenText("schema/AutoScalingLaunchConfigSpecification.json"))
            {
                var serializer = new JsonSerializer();
                return (AwsSchema)serializer.Deserialize(sr, typeof(AwsSchema));
            }
        }
    }
}
