using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataManager.Models;
using System.Web.Http.Results;

namespace CNCDataManager.Controllers.Tests
{
    [TestClass()]
    public class ElasticSlvPinCoupsControllerTests
    {
        [TestMethod()]
        public void GetElasticSlvPinCouplingsTest()
        {
            var con = new ElasticSlvPinCoupsController();
            int expected = 11;

            var result = con.GetElasticSlvPinCouplings();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetElasticSlvPinCoupTest()
        {
            var con = new ElasticSlvPinCoupsController();

            var result = con.GetElasticSlvPinCoup("LT1").GetAwaiter().GetResult() 
                as OkNegotiatedContentResult<ElasticSlvPinCoup>;

            Assert.IsNotNull(result);
        }
    }
}