using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataManager.Models;
using System.Web.Http.Results;
using CNCDataManager.APIs.Controllers;
using CNCDataManager.APIs.Models;

namespace CNCDataManager.Controllers.Tests
{
    [TestClass()]
    public class SrvDriverTransformersControllerTests
    {
        [TestMethod()]
        public void GetSrvDriverTransformersTest()
        {
            var con = new SrvDriverTransformersController();
            int expected = 12;

            var result = con.GetSrvDriverTransformers();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetSrvDriverTransformerTest()
        {
            var con = new SrvDriverTransformersController();

            var result = con.GetSrvDriverTransformer(@"1.5KVA 380/220").GetAwaiter().GetResult()
                as OkNegotiatedContentResult<SrvDriverTransformer>;

            Assert.IsNotNull(result);
        }
    }
}