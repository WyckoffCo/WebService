using GitHub;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Octokit;
using System.IO;
using System.Text.RegularExpressions;

namespace Github.Tests
{

    public abstract class BaseTestClass 
    {

        protected string _orgName;
        protected string _repoName;
        protected GitHub.GitHubHelper Helper;


        public BaseTestClass()
        {
            this._orgName = "WyckoffCo";
            this._repoName = "newRepo-2022-01-07-v2";
        }

        protected void Init()
        {
            IConfiguration Config = new ConfigurationBuilder().AddJsonFile(this.getRootPath("settings.json"))
                   .Build();

            string token = Config.GetSection("GitHub")["token"];

            if (_orgName == "")
                throw new System.Exception("_orgName must be set.");

            this.Helper = new GitHub.GitHubHelper(_orgName, token);

        }

        

//        [TestMethod]
//        public void GetRepo()
//        {
//            Repository repository = Helper.GetRepo(_repoName).Result;
//            Assert.AreEqual(_repoName, repository.Name);
//        }

//        [TestMethod]
//        public void GetRepoNotThere()
//        {
//            var nonExistantRepotName = "this-repo-does-not-exist";
//            Repository repository = Helper.GetRepo(nonExistantRepotName).Result;
//            Assert.IsNull(repository);
//        }




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
