using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataManager.Models;
using System.Web.Http.Results;
using CNCDataManager.APIs.Controllers;
using CNCDataManager.APIs.Models;

namespace CNCDataManager.APIs.Tests
{
    [TestClass()]
    public class RotaryTablesControllerTests
    {
        [TestMethod()]
        public void GetRotaryTablesTest()
        {
            var con = new RotaryTablesController();
            int expected = 1;

            var result = con.GetRotaryTables();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetRotaryTableTest()
        {
            var con = new RotaryTablesController();

            var result = con.GetRotaryTable("SKT56400").GetAwaiter().GetResult()
                as OkNegotiatedContentResult<RotaryTable>;

            Assert.IsNotNull(result);
        }
    }
}