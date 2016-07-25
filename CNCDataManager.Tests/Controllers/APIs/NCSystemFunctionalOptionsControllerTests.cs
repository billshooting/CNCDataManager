using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataManager.Models;
using System.Web.Http.Results;
using CNCDataManager.APIs.Controllers;
using CNCDataManager.APIs.Models;

namespace CNCDataManager.Controllers.Tests
{
    [TestClass()]
    public class NCSystemFunctionalOptionsControllerTests
    {
        [TestMethod()]
        public void GetNCSystemFunctionalOptionsTest()
        {
            var con = new NCSystemFunctionalOptionsController();
            int expected = 18;

            var result = con.GetNCSystemFunctionalOptions();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetNCSystemFunctionalOptionsTest1()
        {
            var con = new NCSystemFunctionalOptionsController();

            var result = con.GetNCSystemFunctionalOption("HNC-180XP-M3").GetAwaiter().GetResult()
                as OkNegotiatedContentResult<NCSystemFunctionalOptions>;

            Assert.IsNotNull(result);
        }
    }
}