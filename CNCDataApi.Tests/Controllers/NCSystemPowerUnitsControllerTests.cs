using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataApi.Models;
using System.Web.Http.Results;

namespace CNCDataApi.Controllers.Tests
{
    [TestClass()]
    public class NCSystemPowerUnitsControllerTests
    {
        [TestMethod()]
        public void GetNCSystemPowerUnitsTest()
        {
            var con = new NCSystemPowerUnitsController();
            int expected = 2;

            var result = con.GetNCSystemPowerUnits();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetNCSystemPowerUnitTest()
        {
            var con = new NCSystemPowerUnitsController();

            var result = con.GetNCSystemPowerUnit("HPW-145U").GetAwaiter().GetResult()
                as OkNegotiatedContentResult<NCSystemPowerUnit>;

            Assert.IsNotNull(result);
        }
    }
}