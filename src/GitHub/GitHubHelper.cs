using Octokit;
using Octokit.Internal;
using System;
using System.Threading.Tasks;

namespace GitHub
{
    public class GitHubHelper
    {
        private string _orgName;
        private GitHubClient _gitHubClient;

        private const string GITHUB_TOKEN = "GitHub_Token";

        public GitHubHelper(string orgName, string gitHubToken)
        {
            if (gitHubToken == "")
                throw new Exception("no GitHub token identified");

            string projectName = "GithubWebService";
            var creds = new InMemoryCredentialStore(new Credentials(gitHubToken));

            _orgName = orgName;
            _gitHubClient = new GitHubClient(new ProductHeaderValue(projectName), creds);
        }

        public async Task<Issue> CreateIssue(string repoName, string issueTitle, string comment)
        {
            var issue = _gitHubClient.Issue.Create(_orgName, repoName, new NewIssue(issueTitle)).Result;
            var issueComment = _gitHubClient.Issue.Comment.Create(
                                                    _orgName,
                                                    repoName,
                                                    issue.Number,
                                                    comment).Result;
            return issue;
        }



        public async Task<BranchProtectionSettings> ProtectBranch(string repoName, string branchName)
        {
            var branchProtectionUpdate = new BranchProtectionSettingsUpdate(new BranchProtectionRequiredReviewsUpdate(true, true, 0));

            var branchProtection = _gitHubClient.Repository.Branch.UpdateBranchProtection(_orgName, repoName, branchName, branchProtectionUpdate).Result;

            return branchProtection;
        }

        public async Task<Repository> GetRepo(string repoName)
        {
            try
            {
                var repo = _gitHubClient.Repository.Get(_orgName, repoName).Result;
                return repo;
            }
            catch (Exception e)
            {
                if (e.InnerException.GetType() == typeof(NotFoundException))
                    return null;
                else
                    throw e;
            }
            
        }

        public async Task<Repository> CreateRepo(string repoName)
        {
            var repo = _gitHubClient.Repository.Create(_orgName, new NewRepository(repoName)).Result;

            return repo;
        }

        //public async Task<object> DeleteRepo(string repoName)
        //{

        //    var result = _gitHubClient.Repository.Delete(_orgName, repoName).Result;
        //    return true;

        //}
    }


}
