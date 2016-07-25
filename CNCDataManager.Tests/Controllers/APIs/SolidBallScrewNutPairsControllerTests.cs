using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataManager.Models;
using System.Web.Http.Results;
using CNCDataManager.APIs.Controllers;
using CNCDataManager.APIs.Models;

namespace CNCDataManager.Controllers.Tests
{
    [TestClass()]
    public class SolidBallScrewNutPairsControllerTests
    {
        [TestMethod()]
        public void GetSolidBallScrewNutPairsTest()
        {
            var con = new SolidBallScrewNutPairsController();
            int expected = 37;

            var result = con.GetSolidBallScrewNutPairs();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetSolidBallScrewNutPairsTest1()
        {
            var con = new SolidBallScrewNutPairsController();

            var result = con.GetSolidBallScrewNutPairs("FFZD12020-5").GetAwaiter().GetResult()
                as OkNegotiatedContentResult<SolidBallScrewNutPairs>;

            Assert.IsNotNull(result);
        }
    }
}