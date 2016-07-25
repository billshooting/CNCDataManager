using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataManager.Models;
using System.Web.Http.Results;
using CNCDataManager.APIs.Controllers;
using CNCDataManager.APIs.Models;

namespace CNCDataManager.Controllers.Tests
{
    [TestClass()]
    public class SpindleBeltParasControllerTests
    {
        [TestMethod()]
        public void GetSpindleBeltParasTest()
        {
            var con = new SpindleBeltParasController();
            int expected = 16;

            var result = con.GetSpindleBeltParas();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetSpindleBeltParaTest()
        {
            var con = new SpindleBeltParasController();

            var result = con.GetSpindleBeltPara("TBN240H075").GetAwaiter().GetResult()
                as OkNegotiatedContentResult<SpindleBeltPara>;

            Assert.IsNotNull(result);
        }
    }
}