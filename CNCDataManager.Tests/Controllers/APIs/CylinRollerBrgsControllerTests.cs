using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataManager.Models;
using System.Web.Http.Results;
using CNCDataManager.APIs.Controllers;
using CNCDataManager.APIs.Models;

namespace CNCDataManager.Controllers.Tests
{
    [TestClass()]
    public class CylinRollerBrgsControllerTests
    {
        [TestMethod()]
        public void GetCylinRollerBearingsTest()
        {
            var con = new CylinRollerBrgsController();
            int expected = 11;

            var result = con.GetCylinRollerBearings();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetCylinRollerBrgTest()
        {
            var con = new CylinRollerBrgsController();

            var result = con.GetCylinRollerBrg("N204E").GetAwaiter().GetResult() 
                as OkNegotiatedContentResult<CylinRollerBrg>;

            Assert.IsNotNull(result);
        }
    }
}