using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataManager.Models;
using System.Web.Http.Results;
using CNCDataManager.APIs.Controllers;
using CNCDataManager.APIs.Models;

namespace CNCDataManager.Controllers.Tests
{
    [TestClass()]
    public class PlumShapedFlexibleCoupsControllerTests
    {
        [TestMethod()]
        public void GetPlumShapedFlexibleCouplingsTest()
        {
            var con = new PlumShapedFlexibleCoupsController();
            int expected = 5;

            var result = con.GetPlumShapedFlexibleCouplings();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetPlumShapedFlexibleCoupTest()
        {
            var con = new PlumShapedFlexibleCoupsController();

            var result = con.GetPlumShapedFlexibleCoup("LM3").GetAwaiter().GetResult()
                as OkNegotiatedContentResult<PlumShapedFlexibleCoup>;

            Assert.IsNotNull(result);
        }
    }
}