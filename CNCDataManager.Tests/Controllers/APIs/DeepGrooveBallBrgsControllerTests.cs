using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataManager.Models;
using System.Web.Http.Results;
using CNCDataManager.APIs.Controllers;
using CNCDataManager.APIs.Models;

namespace CNCDataManager.Controllers.Tests
{
    [TestClass()]
    public class DeepGrooveBallBrgsControllerTests
    {
        [TestMethod()]
        public void GetDeepGrooveBallBearingsTest()
        {
            var con = new DeepGrooveBallBrgsController();
            int expected = 12;

            var result = con.GetDeepGrooveBallBearings();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetDeepGrooveBallBrgTest()
        {
            var con = new DeepGrooveBallBrgsController();

            var result = con.GetDeepGrooveBallBrg("6204").GetAwaiter().GetResult() 
                as OkNegotiatedContentResult<DeepGrooveBallBrg>;

            Assert.IsNotNull(result);
        }
    }
}