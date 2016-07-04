using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataApi.Models;
using System.Web.Http.Results;

namespace CNCDataApi.Controllers.Tests
{
    [TestClass()]
    public class SpindleBeltLengthsControllerTests
    {
        [TestMethod()]
        public void GetSpindleBeltLengthsTest()
        {
            var con = new SpindleBeltLengthsController();
            int expected = 74;

            var result = con.GetSpindleBeltLengths();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetSpindleBeltLengthTest()
        {
            var con = new SpindleBeltLengthsController();

            var result = con.GetSpindleBeltLength(36).GetAwaiter().GetResult()
                as OkNegotiatedContentResult<SpindleBeltLength>;

            Assert.IsNotNull(result);
        }
    }
}