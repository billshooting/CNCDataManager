using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataManager.Models;
using System.Web.Http.Results;
using CNCDataManager.APIs.Controllers;
using CNCDataManager.APIs.Models;

namespace CNCDataManager.Controllers.Tests
{
    [TestClass()]
    public class PMSrvMotorParasControllerTests
    {
        [TestMethod()]
        public void GetPMSrvMotorParasTest()
        {
            var con = new PMSrvMotorParasController();
            int expected = 215;

            var result = con.GetPMSrvMotorParas();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetPMSrvMotorParaTest()
        {
            var con = new PMSrvMotorParasController();

            var result = con.GetPMSrvMotorPara("110SJT-M040D").GetAwaiter().GetResult()
                as OkNegotiatedContentResult<PMSrvMotorPara>;

            Assert.IsNotNull(result);
        }
    }
}