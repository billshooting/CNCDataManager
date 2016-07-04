using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataApi.Models;
using System.Web.Http.Results;

namespace CNCDataApi.Controllers.Tests
{
    [TestClass()]
    public class AlignRollerBrgsControllerTests
    {
        [TestMethod()]
        public void GetAlignRollerBearingsTest()
        {
            var controller = new AlignRollerBrgsController();
            int expected = 11;

            var result = controller.GetAlignRollerBearings();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetAlignRollerBrgTest()
        {
            var controller = new AlignRollerBrgsController();

            var result = controller.GetAlignRollerBrg("22206C").GetAwaiter().GetResult() 
                as OkNegotiatedContentResult<AlignRollerBrg>;

            Assert.IsNotNull(result);
        }
    }
}