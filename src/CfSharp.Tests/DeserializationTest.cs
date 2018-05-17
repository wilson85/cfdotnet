using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Xunit;

namespace CfSharp.Tests
{
    public class SerializationTest
    {
        [Fact]
        public void Test()
        {
            var stack = new Stack("test");
            stack.AutoScalingGroup("TERWS");
            var json = stack.ToJson();

            var obj = DeSerializeStack(json);
        }

        [Fact]
        public void CanDeserializeExample()
        {
            string example = File.ReadAllText("Examples/AutoScalingMultiAZWithNotifications.json");

            var obj = DeSerializeStack(example);

            Assert.NotNull(obj);

        }

        public Object DeSerializeStack(string jsonStack)
        {
            var settings = new JsonSerializerSettings();
            //settings.Converters.Add(JsonSubtypesConverterBuilder
            //    .Of(typeof(Animal), "Type") // type property is only defined here
            //    .RegisterSubtype(typeof(Cat), AnimalType.Cat)
            //    .RegisterSubtype(typeof(Dog), AnimalType.Dog)
            //    .SerializeDiscriminatorProperty() // ask to serialize the type property
            //    .Build());
            return JsonConvert.DeserializeObject<Stack>(jsonStack, settings);
        }

        [Fact]
        public void Demo()
        {
            string json = "[ { \"Ref\": \"Subnets\" } ]";

            var t = JsonConvert.DeserializeObject<List<Object>>(json);
        }
    }


    public class Car
    {
        public string Maker { get; set; }
        public string Model { get; set; }
    }
}
