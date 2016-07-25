using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Web.Http.Results;
using CNCDataManager.Models;
using CNCDataManager.APIs.Controllers;
using CNCDataManager.APIs.Models;

namespace CNCDataManager.Controllers.Tests
{
    [TestClass()]
    public class TaperedRollerBrgsControllerTests
    {
        [TestMethod()]
        public void GetTaperedRollerBearingsTest()
        {
            var con = new TaperedRollerBrgsController();
            int expected = 11;

            var result = con.GetTaperedRollerBearings();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetTaperedRollerBrgTest()
        {
            var con = new TaperedRollerBrgsController();

            var result = con.GetTaperedRollerBrg("30203").GetAwaiter().GetResult()
                as OkNegotiatedContentResult<TaperedRollerBrg>;

            Assert.IsNotNull(result);
        }
    }
}