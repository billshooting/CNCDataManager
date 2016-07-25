using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataManager.Models;
using System.Web.Http.Results;

namespace CNCDataManager.Controllers.Tests
{
    [TestClass()]
    public class SpindleBeltSizesControllerTests
    {
        [TestMethod()]
        public void GetSpindleBeltSizesTest()
        {
            var con = new SpindleBeltSizesController();
            int expected = 4;

            var result = con.GetSpindleBeltSizes();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetSpindleBeltSizeTest()
        {
            var con = new SpindleBeltSizesController();

            var result = con.GetSpindleBeltSize("H").GetAwaiter().GetResult()
                as OkNegotiatedContentResult<SpindleBeltSize>;

            Assert.IsNotNull(result);
        }
    }
}