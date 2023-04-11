using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace csharpdurablefn
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<string> RunOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context, ILogger log)
        {
            var outputs = new List<string>();

            // Replace "hello" with the name of your Durable Activity Function.
            /*outputs.Add(await context.CallActivityAsync<string>("Function1_Hello", "Tokyo"));
            outputs.Add(await context.CallActivityAsync<string>("Function1_Hello", "Seattle"));
            outputs.Add(await context.CallActivityAsync<string>("Function1_Hello", "London"));*/



            // returns ["Hello Tokyo!", "Hello Seattle!", "Hello London!"]

           var x = await context.CallActivityAsync<string>("Function1_Hello", 1);
            var y = await context.CallActivityAsync<string>("Function1_Hello", x);
            var z= await context.CallActivityAsync<string>("Function1_Hello", y);
            outputs.Add($"la valeur totale est {z}");
           log.LogInformation($"la valeur totale est {z}");
            return $"la valeur totale est {z}" ;
        }

       /* [FunctionName("Function1_Hello")]
        public static string SayHello([ActivityTrigger] string name, ILogger log)
        {
            log.LogInformation($"Saying hello to {name}.");

            return $"Hello {name}!";
        }*/

        [FunctionName("Function1_Hello")]
        public static int SayHello([ActivityTrigger] int val, ILogger log)
        {
            int init = val;
            for(int i=0; i <=100000; i++)
            {
                init = init + 1;
                log.LogInformation($"valeur {init}.");
            }
            

            return init;
        }

        [FunctionName("Function1_HttpStart")]
        public static async Task<HttpResponseMessage> HttpStart(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestMessage req,
            [DurableClient] IDurableOrchestrationClient starter,
            ILogger log)
        {
            // Function input comes from the request content.
            string instanceId = await starter.StartNewAsync("Function1", null);

            log.LogInformation($"Started orchestration with ID = '{instanceId}'.");

            return starter.CreateCheckStatusResponse(req, instanceId);
        }

        /*****/
        [FunctionName("Function1_blobStart")]
        public static async Task TaskAsync([BlobTrigger("samples-workitems/{name}", Connection = "mydemo")] Stream myBlob, string name, [DurableClient] IDurableOrchestrationClient starter, ILogger log)
        {
            // Function input comes from the request content.
            string instanceId = await starter.StartNewAsync("Function1", null);
            // log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");

            log.LogInformation($"Started orchestration with ID = '{instanceId}'.");
    
        }
        /****/
    }
}