using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Web.Http.Results;
using CNCDataManager.APIs.Controllers;
using CNCDataManager.APIs.Models;

namespace CNCDataManager.Controllers.Tests
{
    [TestClass()]
    public class StepMotorSizesControllerTests
    {
        [TestMethod()]
        public void GetStepMotorSizesTest()
        {
            var con = new StepMotorSizesController();
            int expected = 0;

            var result = con.GetStepMotorSizes();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetStepMotorSizeTest()
        {
            var con = new StepMotorSizesController();

            var result = con.GetStepMotorSize("1").GetAwaiter().GetResult()
                as NotFoundResult;

            Assert.IsNotNull(result);
        }
    }
}