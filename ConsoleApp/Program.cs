using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text.Json;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


//            var x = SetBranchProtectionAsync("WyckoffCo", "newRepo1", "main");
            var x = CreateIssueAsync("WyckoffCo", "newRepo1");



        }

        private static async Task SetBranchProtectionAsync(string orgName, string repoName, string branchName)
        {
            string url = string.Format("https://api.github.com/repos/{0}/{1}/branches/{2}/protection", orgName, repoName, branchName);
            string token = "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";
            var client = new HttpClient { BaseAddress = new Uri(url) };
            client.DefaultRequestHeaders.Add("User-Agent", "C# console program");
            client.DefaultRequestHeaders.Add("Authorization", string.Format("token {0}",token));
            client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");


            string jsonData = @"{ 
                                'required_status_checks': {
                                  'strict' : true,
                                  'contexts': []
                                },
                                'enforce_admins': true,
                                'required_pull_request_reviews': {
                                  'dismissal_restrictions': {},
                                  'dismiss_stale_reviews': true,
                                  'require_code_owner_reviews': false,
                                  'required_approving_review_count': 1
                                },
                                'restrictions': null,
                                'required_linear_history': false,
                                'allow_force_pushes': false,
                                'allow_deletions': false
                              }";

            var content = new StringContent(jsonData);
            //HttpRequestMessage request = new HttpRequestMessage();
            //request.Content = JsonConvert.

//            client.con
            HttpResponseMessage response = await client.PutAsync(url, content);

        }

        private static async Task CreateIssueAsync(string orgName, string repoName)
        {
            string url = string.Format("https://api.github.com/repos/{0}/{1}", orgName, repoName);
            string token = "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";
            var client = new HttpClient { BaseAddress = new Uri(url) };
            client.DefaultRequestHeaders.Add("User-Agent", "C# console program");
            client.DefaultRequestHeaders.Add("Authorization", string.Format("token {0}", token));
            client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");





            string s = File.ReadAllText("create-issue.json");

           



            //System.Text.Json.JsonDocument





            //dynamic obj = new JObject();
            //obj.Title = "test";


//            var j = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

////            var j2 = Newtonsoft.Json.JsonConverter().





//            string jsonData = @"{ 
//                                'title': 'test'
//                              }";

//            var content = new StringContent(jsonData);
//            HttpContent httpContent = content;
//            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
//            //HttpRequestMessage request = new HttpRequestMessage();
//            //request.Content = JsonConvert.

//            //            client.con
//            HttpResponseMessage response = await client.PostAsync(url, httpContent);

//            var i = 1;
        }


    }
}
