using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataApi.Models;
using System.Web.Http.Results;

namespace CNCDataApi.Controllers.Tests
{
    [TestClass()]
    public class HubShapedCoupsControllerTests
    {
        [TestMethod()]
        public void GetHubShapedCouplingsTest()
        {
            var con = new HubShapedCoupsController();
            int expected = 10;

            var result = con.GetHubShapedCouplings();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetHubShapedCoupTest()
        {
            var con = new HubShapedCoupsController();

            var result = con.GetHubShapedCoup("XLJ1").GetAwaiter().GetResult()
                as OkNegotiatedContentResult<HubShapedCoup>;

            Assert.IsNotNull(result);
        }
    }
}