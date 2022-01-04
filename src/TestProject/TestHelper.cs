using GitHub;
using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Octokit;
using System.IO;
using System.Text.RegularExpressions;

namespace TestProject
{

    [TestClass]
    public class GitHubTests 
    {

        string _orgName = "WyckoffCo";
        internal string ProjectName = "GithubWebService";
        internal GitHubHelper Helper;


        public GitHubTests()
        {

            IConfiguration Config = new ConfigurationBuilder().AddJsonFile(this.getRootPath("settings.json"))
                .Build();

            string token = Config.GetSection("GitHub")["token"]; 

            this.Helper = new GitHubHelper(_orgName,token);

        }

        [TestMethod]
        public void IssueHasMessage()
        {
            var message = "Branch Protection created.";
            var comment = "Branch protection of XYZ was created.  @jwyckoff";
            var name = "newRepo1";
            Issue issue = this.Helper.CreateIssue(name,message,comment).Result;

            Assert.IsNotNull(issue);

            Assert.AreEqual(issue.Title, message);
        }

        [TestMethod]
        public void GetRepo1()
        {
            var name = "newRepo1";
            Repository repository = Helper.GetRepo(name).Result;
            Assert.AreEqual(name, repository.Name);

        }

        [TestMethod]
        public void GetRepoNotThere()
        {
            var name = "asdfasdfasdf";
            Repository repository = Helper.GetRepo(name).Result;
            Assert.IsNull(repository);
        }



        [TestMethod]
        public void ProtectBranch()
        {
            var repoName = "newRepo1";
            var branchName = "main";
            var result = Helper.ProtectBranch(repoName, branchName);

            Assert.IsNotNull(result);

            Assert.IsTrue(result.Id > 0);

        }
        internal string getRootPath(string rootFilename)
        {
            string _root;
            var rootDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            Regex matchThepath = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = matchThepath.Match(rootDir).Value;
            _root = Path.Combine(appRoot, rootFilename);

            return _root;
        }

    }


    }
