using SigmaAPI.Controllers;
using SigmaAPI.Models;

namespace SegmaTestUnit
{
    [TestClass()]
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

            testSigma = new SegmaData { Firstname = "Esaa", Lastname = "Yared", Phonenumber = "00962798033517", Email = "ddd", Timeinterval = "4:00", LinkedInprofileURL = "", GitHubprofileURL = "", Freetextcomment = "" };

            return testSigma;
        }
    }
}