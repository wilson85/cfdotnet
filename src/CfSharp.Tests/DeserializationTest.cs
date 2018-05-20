using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            string example = System.IO.File.ReadAllText("Examples/AutoScalingMultiAZWithNotifications.json");

            var obj = DeSerializeStack(example);

            Assert.NotNull(obj);

        }

        [Fact]
        public void CanDeserializeComplexProperties()
        {
            string example = System.IO.File.ReadAllText("Examples/TypesOfValue.json");

            var obj = DeSerializeStack(example);

            Assert.NotNull(obj);

            var reference = obj.LoadBalancer("ApplicationLoadBalancer").Properties.Subnets[0] as EntityReference;
            Assert.Equal("Subnets", reference.Ref);

            var str = obj.LoadBalancer("ApplicationLoadBalancer").Properties.Subnets[1] as string;
            Assert.Equal("My-Subnet", str);

            var join = obj.LoadBalancer("ApplicationLoadBalancer").Properties.Subnets[2] as FnJoin;
            Assert.Equal("really-complicated", (join.Array[1] as List<object>)[0] as string);


        }

        public Stack DeSerializeStack(string jsonStack)
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new CfPrimitiveJsonConverter());
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
