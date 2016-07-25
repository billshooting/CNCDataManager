using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataManager.Models;
using System.Web.Http.Results;
using CNCDataManager.APIs.Controllers;
using CNCDataManager.APIs.Models;

namespace CNCDataManager.Controllers.Tests
{
    [TestClass()]
    public class NCSystemManualsControllerTests
    {
        [TestMethod()]
        public void GetNCSystemManualsTest()
        {
            var con = new NCSystemManualsController();
            int expected = 4;

            var result = con.GetNCSystemManuals();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetNCSystemManualTest()
        {
            var con = new NCSystemManualsController();

            var result = con.GetNCSystemManual("3轴").GetAwaiter().GetResult()
                as OkNegotiatedContentResult<NCSystemManual>;

            Assert.IsNotNull(result);
        }
    }
}