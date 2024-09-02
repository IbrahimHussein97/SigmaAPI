using Microsoft.VisualStudio.TestTools.UnitTesting;
using SigmaAPI.Controllers;
using SigmaAPI.Models;

namespace SigmaTestUnit
{
    [TestClass]
    public class UnitTest1
    {
      
        [TestMethod()]
        public void CheckInsertSuccessfully()
        {
            var obj = GetObject();
            var controller = new SigmaTaskController();

            var result = controller.SaveData(obj);
            Assert.AreEqual(true, result.IsCompletedSuccessfully);
        }
        private SegmaData GetObject()
        {
            var testSigma = new SegmaData();

            testSigma = new SegmaData { Firstname = "Ibrahim", Lastname = "Hussein", Phonenumber = "00962798033517", Email = "Ibrahimmzhussein@gmail.com", Timeinterval = "4:00", LinkedInprofileURL = "", GitHubprofileURL = "", Freetextcomment = "" };

            return testSigma;
        }
    }
}