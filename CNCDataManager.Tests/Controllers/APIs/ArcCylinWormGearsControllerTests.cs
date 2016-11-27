using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Web.Http.Results;
using CNCDataManager.APIs.Controllers;
using CNCDataManager.APIs.Models;

namespace CNCDataManager.APIs.Tests
{
    [TestClass()]
    public class ArcCylinWormGearsControllerTests
    {
        [TestMethod()]
        public void GetArcCylinWormGearsTest()
        {
            var controller = new ArcCylinWormGearsController();
            int expected = 3;

            var result = controller.GetArcCylinWormGears();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetArcCylinWormGearTest()
        {
            var controller = new ArcCylinWormGearsController();

            var result = controller.GetArcCylinWormGear("1").GetAwaiter().GetResult() 
                as OkNegotiatedContentResult<ArcCylinWormGear>;

            Assert.IsNotNull(result);
        }
    }
}