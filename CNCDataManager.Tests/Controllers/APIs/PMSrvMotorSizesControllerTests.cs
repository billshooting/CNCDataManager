using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataManager.Models;
using System.Web.Http.Results;
using CNCDataManager.APIs.Controllers;
using CNCDataManager.APIs.Models;

namespace CNCDataManager.Controllers.Tests
{
    [TestClass()]
    public class PMSrvMotorSizesControllerTests
    {
        [TestMethod()]
        public void GetPMSrvMotorSizesTest()
        {
            var con = new PMSrvMotorSizesController();
            int expected = 22;

            var result = con.GetPMSrvMotorSizes();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetPMSrvMotorSizeTest()
        {
            var con = new PMSrvMotorSizesController();

            var result = con.GetPMSrvMotorSize("110SJT-M040D").GetAwaiter().GetResult()
                as OkNegotiatedContentResult<PMSrvMotorSize>;

            Assert.IsNotNull(result);
        }
    }
}