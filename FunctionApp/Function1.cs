using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Octokit;
using Octokit.Internal;

namespace FunctionApp2
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);


            string repoName = data?.repository.name;
            string repoUrl = data?.repository.html_url;

// temp();


            string responseMessage = string.IsNullOrEmpty(repoName)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello! Repo '{repoName}' was just created.";

            return new OkObjectResult(responseMessage);
        }

        private static void temp()
        {
           
            
            
            throw new NotImplementedException();
        }





        //private static async Task CreateBranchProtectionAsync()
        //{

        //    //InMemoryCredentialStore credentials = new InMemoryCredentialStore(new Credentials("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"));

        //    //GitHubClient githubClient = new GitHubClient(new ProductHeaderValue("ophion"), credentials);

        //    //// Get the "main" branch.  This is assuming a branch 'main' exists.
        //    //// TODO: remove assumption.

        //    //var repo = await githubClient.Repository.Get("WyckoffCo", "newRepo1");

        //    //var org = await githubClient.Organization.Get("WyckoffCo");

        //    ////githubClient.

        //    ////repo.admi
        //    ////var org = githubClient.Organization.Get("WyckoffCo");

        //    ////org.Start()
        //    //var branch = await githubClient.Repository.Branch.Get("WyckoffCo", "newRepo1","main");

        //    //// if no 'main', create one

        //    //// if main, then create branch protection

        //}
    }
}
