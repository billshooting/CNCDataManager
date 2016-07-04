using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataApi.Models;
using System.Web.Http.Results;

namespace CNCDataApi.Controllers.Tests
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