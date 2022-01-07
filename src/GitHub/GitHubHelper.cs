using Octokit;
using Octokit.Internal;
using System;
using System.Threading.Tasks;

namespace GitHub
{
    public class GitHubHelper
    {
        protected string _orgName;
        protected GitHubClient _gitHubClient;

        protected const string GITHUB_TOKEN = "GitHub_Token";
        protected const string ISSUE_DEFAULT_TITLE = "Branch 'main' protection added.";
        protected const string ISSUE_DEFAULT_COMMENT = "The 'main' branch was protected requiring PRs and code review.  FYI: @jwyckoff";


        public GitHubHelper(string orgName, string gitHubToken)
        {
            if (gitHubToken == "")
                throw new Exception("no GitHub token identified");

            string projectName = "GithubWebService";
            var creds = new InMemoryCredentialStore(new Credentials(gitHubToken));

            _orgName = orgName;
            _gitHubClient = new GitHubClient(new ProductHeaderValue(projectName), creds);
        }

        /// <summary>
        /// Creates an issue and adds comments
        /// </summary>
        /// <param name="repoName">Name of the repo.</param>
        /// <param name="issueTitle">The title/message of the new issue.</param>
        /// <param name="comment">the contents of the added comment.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates an issue and adds comments with default values.
        /// </summary>
        /// <param name="repoName">name of the repo.</param>
        /// <returns></returns>
        public async Task<Issue> CreateIssue(string repoName)
        {
            return CreateIssue(repoName, ISSUE_DEFAULT_TITLE, ISSUE_DEFAULT_COMMENT).Result;
        }


        public async Task<BranchProtectionSettings> ProtectBranch(string repoName, string branchName)
        {
            var branchProtectionUpdate = new BranchProtectionSettingsUpdate(new BranchProtectionRequiredReviewsUpdate(true, true, 0));

            var branchProtection = _gitHubClient.Repository.Branch.UpdateBranchProtection(_orgName, repoName, branchName, branchProtectionUpdate).Result;

            return branchProtection;
        }

        public async Task<bool> RemoveProtectBranch(string repoName, string branchName)
        {

            var branchProtectionDeleted = _gitHubClient.Repository.Branch.DeleteBranchProtection(_orgName, repoName, branchName).Result;

            return branchProtectionDeleted;
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

    }


}
