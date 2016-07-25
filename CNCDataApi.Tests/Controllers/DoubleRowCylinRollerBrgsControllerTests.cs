using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataManager.Models;
using System.Web.Http.Results;

namespace CNCDataManager.Controllers.Tests
{
    [TestClass()]
    public class DoubleRowCylinRollerBrgsControllerTests
    {
        [TestMethod()]
        public void GetDoubleRowCylinRollerBearingsTest()
        {
            var con = new DoubleRowCylinRollerBrgsController();
            int expected = 1;

            var result = con.GetDoubleRowCylinRollerBearings();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
            
        }

        [TestMethod()]
        public void GetDoubleRowCylinRollerBrgTest()
        {
            var con = new DoubleRowCylinRollerBrgsController();

            var result = con.GetDoubleRowCylinRollerBrg("NN3005").GetAwaiter().GetResult() 
                as OkNegotiatedContentResult<DoubleRowCylinRollerBrg>;

            Assert.IsNotNull(result);
        }
    }
}