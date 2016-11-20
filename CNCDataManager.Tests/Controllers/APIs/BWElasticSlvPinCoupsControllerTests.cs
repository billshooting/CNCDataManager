using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Web.Http.Results;
using CNCDataManager.APIs.Controllers;
using CNCDataManager.APIs.Models;

namespace CNCDataManager.APIs.Tests
{
    [TestClass()]
    public class BWElasticSlvPinCoupsControllerTests
    {
        [TestMethod()]
        public void GetBWElasticSlvPinCouplingsTest()
        {
            var con = new BWElasticSlvPinCoupsController();
            int expected = 6;

            var result = con.GetBWElasticSlvPinCouplings();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetBWElasticSlvPinCoupTest()
        {
            var con = new BWElasticSlvPinCoupsController();

            var result = con.GetBWElasticSlvPinCoup("LT10").GetAwaiter().GetResult() 
                as OkNegotiatedContentResult<BWElasticSlvPinCoup>;

            Assert.IsNotNull(result);
        }
    }
}