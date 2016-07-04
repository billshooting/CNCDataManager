using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Web.Http.Results;
using CNCDataApi.Models;

namespace CNCDataApi.Controllers.Tests
{
    [TestClass()]
    public class XTaperedRollerBrgsControllerTests
    {
        [TestMethod()]
        public void GetXTaperedRollerBearingsTest()
        {
            var con = new XTaperedRollerBrgsController();
            int expected = 1;

            var result = con.GetXTaperedRollerBearings();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetXTaperedRollerBrgTest()
        {
            var con = new XTaperedRollerBrgsController();

            var result = con.GetXTaperedRollerBrg("150XRN23").GetAwaiter().GetResult()
                as OkNegotiatedContentResult<XTaperedRollerBrg>;

            Assert.IsNotNull(result);
        }
    }
}