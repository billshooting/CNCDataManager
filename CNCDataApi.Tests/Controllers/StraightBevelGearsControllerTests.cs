using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Web.Http.Results;
using CNCDataApi.Models;

namespace CNCDataApi.Controllers.Tests
{
    [TestClass()]
    public class StraightBevelGearsControllerTests
    {
        [TestMethod()]
        public void GetStraightBevelGearsTest()
        {
            var con = new StraightBevelGearsController();
            int expected = 2;

            var result = con.GetStraightBevelGears();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetStraightBevelGearTest()
        {
            var con = new StraightBevelGearsController();

            var result = con.GetStraightBevelGear("1").GetAwaiter().GetResult()
                as OkNegotiatedContentResult<StraightBevelGear>;

            Assert.IsNotNull(result);
        }
    }
}