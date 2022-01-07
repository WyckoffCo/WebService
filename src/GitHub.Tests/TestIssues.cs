using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GitHub;
using Octokit;

namespace Github.Tests
{
    [TestClass]
    public class TestIssues : BaseTestClass
    {
        Issue issue;
        string message = "UNIT TEST: test new issue.";
        string comment = "UNIT TEST: test to adding new comment.";

        public TestIssues() 
        {
            this.Init();
        }


        [TestInitialize]
        public void TestInitialize()
        {

            issue = this.Helper.CreateIssue(_repoName, message, comment).Result;

        }

        [TestMethod]
        public void IsIssueCreated()
        {
            Assert.IsNotNull(issue);
        }

        [TestMethod]
        public void IsTitleCorrect()
        {
            Assert.AreEqual(issue.Title, message);
        }

        

    }
}
