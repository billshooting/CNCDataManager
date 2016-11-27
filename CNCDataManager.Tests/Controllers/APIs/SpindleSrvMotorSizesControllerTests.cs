using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataManager.Models;
using System.Web.Http.Results;
using CNCDataManager.APIs.Controllers;
using CNCDataManager.APIs.Models;

namespace CNCDataManager.APIs.Tests
{
    [TestClass()]
    public class SpindleSrvMotorSizesControllerTests
    {
        [TestMethod()]
        public void GetSpindleSrvMotorSizesTest()
        {
            var con = new SpindleSrvMotorSizesController();
            int expected = 60;

            var result = con.GetSpindleSrvMotorSizes();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetSpindleSrvMotorSizeTest()
        {
            var con = new SpindleSrvMotorSizesController();

            var result = con.GetSpindleSrvMotorSize("CTB-4011ZXB30").GetAwaiter().GetResult()
                as OkNegotiatedContentResult<SpindleSrvMotorSize>;

            Assert.IsNotNull(result);
        }
    }
}