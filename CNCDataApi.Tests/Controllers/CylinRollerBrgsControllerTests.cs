using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataApi.Models;
using System.Web.Http.Results;

namespace CNCDataApi.Controllers.Tests
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