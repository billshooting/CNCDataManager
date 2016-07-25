using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataManager.Models;
using System.Web.Http.Results;

namespace CNCDataManager.Controllers.Tests
{
    [TestClass()]
    public class AngContactBallBrgsControllerTests
    {
        [TestMethod()]
        public void GetAngContactBallBearingsTest()
        {
            var controller = new AngContactBallBrgsController();
            int expected = 11;

            var result = controller.GetAngContactBallBearings();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetAngContactBallBrgTest()
        {
            var controller = new AngContactBallBrgsController();

            var result = controller.GetAngContactBallBrg("7204A").GetAwaiter().GetResult() 
                as OkNegotiatedContentResult<AngContactBallBrg>;

            Assert.IsNotNull(result);
        }
    }
}