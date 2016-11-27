using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataManager.Models;
using System.Web.Http.Results;
using CNCDataManager.APIs.Controllers;
using CNCDataManager.APIs.Models;

namespace CNCDataManager.APIs.Tests
{
    [TestClass()]
    public class ElecSpindleParasControllerTests
    {
        [TestMethod()]
        public void GetElecSpindleParasTest()
        {
            var con = new ElecSpindleParasController();
            int expected = 2;

            var result = con.GetElecSpindleParas();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetElecSpindleParaTest()
        {
            var con = new ElecSpindleParasController();

            var result = con.GetElecSpindlePara("GMFE05A-4CY").GetAwaiter().GetResult() 
                as OkNegotiatedContentResult<ElecSpindlePara>;

            Assert.IsNotNull(result);
        }
    }
}