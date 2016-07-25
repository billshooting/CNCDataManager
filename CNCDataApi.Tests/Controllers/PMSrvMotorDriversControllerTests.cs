using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataManager.Models;
using System.Web.Http.Results;

namespace CNCDataManager.Controllers.Tests
{
    [TestClass()]
    public class PMSrvMotorDriversControllerTests
    {
        [TestMethod()]
        public void GetPMSrvMotorDriversTest()
        {
            var con = new PMSrvMotorDriversController();
            int expected = 46;

            var result = con.GetPMSrvMotorDrivers();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetPMSrvMotorDriverTest()
        {
            var con = new PMSrvMotorDriversController();

            var result = con.GetPMSrvMotorDriver("GJS008ADA").GetAwaiter().GetResult()
                as OkNegotiatedContentResult<PMSrvMotorDriver>;

            Assert.IsNotNull(result);
        }
    }
}