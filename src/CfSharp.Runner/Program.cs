using System;
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
            stack.LoadBalancer("lb", lb => lb.Scheme(Scheme.InternetFacing));

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
