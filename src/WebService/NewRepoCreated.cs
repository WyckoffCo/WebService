using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace WebService
{
    public static class NewRepoCreated
    {
        internal static bool ProtectAndCreateIssue(string repoName)
        {
            string branchName = "main";
            string orgName = "WyckoffCo";

            string token = Environment.GetEnvironmentVariable("GitHub_Token");

            GitHub.GitHubHelper helper = new GitHub.GitHubHelper(orgName, token);

            var branchProtectionSettings = helper.ProtectBranch(repoName, branchName);

            var issue = helper.CreateIssue(repoName, "'main' branch protected.", "The 'main' branch was protected requiring PRs and code review.  FYI: @jwyckoff");

            return true;

        }
        [FunctionName("NewRepoCreated")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Admin, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {


            string responseMessage = "Only listening not a create.";


            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            string repoName;

            if (data?.action == "created")
            {
                repoName = data?.repository.name;
                responseMessage = $"Hello! Repo '{repoName}' was just created.";

                ProtectAndCreateIssue(repoName);
            }
            else
            {
                if (req.Query["test"] == "y")
                {
                    ProtectAndCreateIssue(req.Query["repoName"]);
                }
                responseMessage = $"Hello! The GitHub notified this service that something happened, but this listener only cares about 'created'.";
            }

            log.LogInformation(responseMessage);

            return new OkObjectResult(responseMessage);
        }
    }
}
