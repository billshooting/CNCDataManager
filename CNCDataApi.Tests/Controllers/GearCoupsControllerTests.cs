using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Web.Http.Results;
using CNCDataApi.Models;

namespace CNCDataApi.Controllers.Tests
{
    [TestClass()]
    public class GearCoupsControllerTests
    {
        [TestMethod()]
        public void GetGearCouplingsTest()
        {
            var con = new GearCoupsController();
            int expected = 2;

            var result = con.GetGearCouplings();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetGearCoupTest()
        {
            var con = new GearCoupsController();

            var result = con.GetGearCoup("GICL1").GetAwaiter().GetResult() 
                as OkNegotiatedContentResult<GearCoup>;

            Assert.IsNotNull(result);
        }
    }
}