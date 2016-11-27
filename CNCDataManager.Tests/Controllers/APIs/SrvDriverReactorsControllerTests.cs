using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataManager.Models;
using System.Web.Http.Results;
using CNCDataManager.APIs.Controllers;
using CNCDataManager.APIs.Models;

namespace CNCDataManager.APIs.Tests
{
    [TestClass()]
    public class SrvDriverReactorsControllerTests
    {
        [TestMethod()]
        public void GetSrvDriverReactorsTest()
        {
            var con = new SrvDriverReactorsController();
            int expected = 12;

            var result = con.GetSrvDriverReactors();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetSrvDriverReactorTest()
        {
            var con = new SrvDriverReactorsController();

            var result = con.GetSrvDriverReactor(@"ACL-11kW").GetAwaiter().GetResult()
                as OkNegotiatedContentResult<SrvDriverReactor>;

            Assert.IsNotNull(result);
        }
    }
}