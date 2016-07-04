using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataApi.Models;
using System.Web.Http.Results;

namespace CNCDataApi.Controllers.Tests
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