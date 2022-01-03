using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FunctionApp2
{
    public static class Function2
    {
        [FunctionName("Function2")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string responseMessage = "Only listening not a create.";

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            if (data?.action == "created")
            {
                string repoName = data?.repository.name;
                responseMessage = $"Hello! Repo '{repoName}' was just created.";
            }
            else
            {
                responseMessage = $"Hello! The GitHub notified this service that something happened, but this listener only cares about 'created'.";
            }

            log.LogInformation(responseMessage);
            return new OkObjectResult(responseMessage);
        }
    }
}
