using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataManager.Models;
using System.Web.Http.Results;
using CNCDataManager.APIs.Controllers;
using CNCDataManager.APIs.Models;

namespace CNCDataManager.Controllers.Tests
{
    [TestClass()]
    public class ElecSpindleSizesControllerTests
    {
        [TestMethod()]
        public void GetElecSpindleSizesTest()
        {
            var con = new ElecSpindleSizesController();
            int expected = 2;

            var result = con.GetElecSpindleSizes();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetElecSpindleSizeTest()
        {
            var con = new ElecSpindleSizesController();

            var result = con.GetElecSpindleSize("GMFE05A-4CY").GetAwaiter().GetResult()
                as OkNegotiatedContentResult<ElecSpindleSize>;

            Assert.IsNotNull(result);
        }
    }
}