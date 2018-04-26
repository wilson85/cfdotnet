using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon;
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;

namespace CfSharp.Runner
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            Stack stack = new Stack("test");
            var cfg = stack.LaunchConfiguration("lc")
                .Metadata.Init.Config("config1");

            cfg.Command("print1").Command("print \"hello world\"");


            string json = stack.ToJson();

            AmazonCloudFormationClient client = new AmazonCloudFormationClient(RegionEndpoint.EUWest1);

            try
            {
                var result = await client.ValidateTemplateAsync(new ValidateTemplateRequest()
                {
                    TemplateBody = json
                });

                Console.WriteLine("CF format OK");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadKey();
        }
    }
}
