using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataManager.Models;
using System.Web.Http.Results;
using CNCDataManager.APIs.Controllers;
using CNCDataManager.APIs.Models;

namespace CNCDataManager.Controllers.Tests
{
    [TestClass()]
    public class SrvDriverBrakeResistorsControllerTests
    {
        [TestMethod()]
        public void GetSrvDriverBrakeResistorsTest()
        {
            var con = new SrvDriverBrakeResistorsController();
            int expected = 10;

            var result = con.GetSrvDriverBrakeResistors();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetSrvDriverBrakeResistorTest()
        {
            var con = new SrvDriverBrakeResistorsController();

            var result = con.GetSrvDriverBrakeResistor("1").GetAwaiter().GetResult()
                as OkNegotiatedContentResult<SrvDriverBrakeResistor>;

            Assert.IsNotNull(result);
        }
    }
}