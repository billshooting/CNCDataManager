using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataManager.Models;
using System.Web.Http.Results;
using CNCDataManager.APIs.Controllers;
using CNCDataManager.APIs.Models;

namespace CNCDataManager.APIs.Tests
{
    [TestClass()]
    public class NCSystemsControllerTests
    {
        [TestMethod()]
        public void GetNCSystemsTest()
        {
            var con = new NCSystemsController();
            int expected = 70;

            var result = con.GetNCSystems();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetNCSystemTest()
        {
            var con = new NCSystemsController();

            var result = con.GetNCSystem(1).GetAwaiter().GetResult()
                as OkNegotiatedContentResult<NCSystem>;

            Assert.IsNotNull(result);
        }
    }
}