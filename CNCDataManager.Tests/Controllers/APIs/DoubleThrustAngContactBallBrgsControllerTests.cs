using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataManager.Models;
using System.Web.Http.Results;
using CNCDataManager.APIs.Controllers;
using CNCDataManager.APIs.Models;

namespace CNCDataManager.APIs.Tests
{
    [TestClass()]
    public class DoubleThrustAngContactBallBrgsControllerTests
    {
        [TestMethod()]
        public void GetDoubleThrustAngContactBallBearingsTest()
        {
            var con = new DoubleThrustAngContactBallBrgsController();
            int expected = 4;

            var result = con.GetDoubleThrustAngContactBallBearings();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetDoubleThrustAngContactBallBrgTest()
        {
            var con = new DoubleThrustAngContactBallBrgsController();

            var result = con.GetDoubleThrustAngContactBallBrg(@"234406B/P5").GetAwaiter().GetResult() 
                as OkNegotiatedContentResult<DoubleThrustAngContactBallBrg>;

            Assert.IsNotNull(result);
        }
    }
}