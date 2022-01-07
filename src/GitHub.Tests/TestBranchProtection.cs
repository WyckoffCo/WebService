using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Github.Tests
{
    [TestClass]
    public class TestBranchProtection : BaseTestClass


    {

        string branchName = "main";

        public TestBranchProtection()
        {
            this.Init();
        }


        [TestInitialize]
        public void TestInitialize()
        {
            var result = this.Helper.RemoveProtectBranch(this._repoName, this.branchName);
        }

        [TestMethod]
        public void ProtectBranch()
        {
            var result = this.Helper.ProtectBranch(this._repoName, branchName);
            Assert.IsNotNull(result);
        }


        [TestCleanup]
        public void TestCleanup()
        {
            var result = this.Helper.RemoveProtectBranch(this._repoName, this.branchName);
        }
       
    }
}
