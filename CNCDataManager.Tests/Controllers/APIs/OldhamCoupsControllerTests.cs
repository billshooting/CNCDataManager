using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataManager.Models;
using System.Web.Http.Results;
using CNCDataManager.APIs.Controllers;
using CNCDataManager.APIs.Models;
namespace CNCDataManager.Controllers.Tests
{
    [TestClass()]
    public class OldhamCoupsControllerTests
    {
        [TestMethod()]
        public void GetOldhamCouplingsTest()
        {
            var con = new OldhamCoupsController();
            int expected = 13;

            var result = con.GetOldhamCouplings();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetOldhamCoupTest()
        {
            var con = new OldhamCoupsController();

            var result = con.GetOldhamCoup("1").GetAwaiter().GetResult()
                as OkNegotiatedContentResult<OldhamCoup>;

            Assert.IsNotNull(result);
        }
    }
}