using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataManager.Models;
using System.Web.Http.Results;
using CNCDataManager.APIs.Controllers;
using CNCDataManager.APIs.Models;

namespace CNCDataManager.APIs.Tests
{
    [TestClass()]
    public class SpindleSrvMotorDriversControllerTests
    {
        [TestMethod()]
        public void GetSpindleSrvMotorDriversTest()
        {
            var con = new SpindleSrvMotorDriversController();
            int expected = 16;

            var result = con.GetSpindleSrvMotorDrivers();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetSpindleSrvMotorDriverTest()
        {
            var con = new SpindleSrvMotorDriversController();

            var result = con.GetSpindleSrvMotorDriver("HSV-180AS-035").GetAwaiter().GetResult()
                as OkNegotiatedContentResult<SpindleSrvMotorDriver>;

            Assert.IsNotNull(result);
        }
    }
}