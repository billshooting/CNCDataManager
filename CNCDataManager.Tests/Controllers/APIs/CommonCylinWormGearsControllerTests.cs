using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataManager.Models;
using System.Web.Http.Results;
using CNCDataManager.APIs.Controllers;
using CNCDataManager.APIs.Models;

namespace CNCDataManager.Controllers.Tests
{
    [TestClass()]
    public class CommonCylinWormGearsControllerTests
    {
        [TestMethod()]
        public void GetCommonCylinWormGearsTest()
        {
            var con = new CommonCylinWormGearsController();
            int expected = 2;

            var result = con.GetCommonCylinWormGears();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetCommonCylinWormGearTest()
        {
            var con = new CommonCylinWormGearsController();

            var result = con.GetCommonCylinWormGear("1").GetAwaiter().GetResult() 
                as OkNegotiatedContentResult<CommonCylinWormGear>;

            Assert.IsNotNull(result);
        }
    }
}