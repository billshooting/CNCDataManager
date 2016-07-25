using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using CNCDataManager.Models;
using CNCDataManager.APIs.Controllers;
using CNCDataManager.APIs.Models;

namespace CNCDataManager.Controllers.Tests
{
    [TestClass()]
    public class HeliCylinGearsControllerTests
    {
        [TestMethod()]
        public void GetHeliCylinGearsTest()
        {
            var con = new HeliCylinGearsController();
            int expected = 2;

            var result = con.GetHeliCylinGears();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetHeliCylinGearTest()
        {
            var con = new HeliCylinGearsController();

            IHttpActionResult result = con.GetHeliCylinGear("1").GetAwaiter().GetResult() 
                as OkNegotiatedContentResult<HeliCylinGear>;

            Assert.IsNotNull(result);
        }
    }
}