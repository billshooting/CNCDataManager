using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Web.Http.Results;
using CNCDataManager.APIs.Controllers;
using CNCDataManager.APIs.Models;

namespace CNCDataManager.APIs.Tests
{
    [TestClass()]
    public class NeedleRollerThrustRollerBrgsControllerTests
    {
        [TestMethod()]
        public void GetNeedleRollerThrustRollerBearingsTest()
        {
            var con = new NeedleRollerThrustRollerBrgsController();
            int expected = 0;

            var result = con.GetNeedleRollerThrustRollerBearings();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetNeedleRollerThrustRollerBrgTest()
        {
            var con = new NeedleRollerThrustRollerBrgsController();

            var result = con.GetNeedleRollerThrustRollerBrg("1").GetAwaiter().GetResult()
                as NotFoundResult; ;

            Assert.IsNotNull(result);
        }
    }
}