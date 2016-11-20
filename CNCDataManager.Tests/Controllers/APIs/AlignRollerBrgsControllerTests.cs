using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Web.Http.Results;
using CNCDataManager.APIs.Controllers;
using CNCDataManager.APIs.Models;

namespace CNCDataManager.APIs.Tests
{
    [TestClass()]
    public class AlignRollerBrgsControllerTests
    {
        [TestMethod()]
        public void GetAlignRollerBearingsTest()
        {
            var controller = new AlignRollerBrgsController();
            int expected = 11;

            var result = controller.GetAlignRollerBearings();
            foreach(var r in result)
            {
                //r.TypeID = r.TypeID.Trim();
                r.Manufacturer = r.Manufacturer.Trim();
            }
            controller.SaveChanges();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetAlignRollerBrgTest()
        {
            var controller = new AlignRollerBrgsController();

            var result = controller.GetAlignRollerBrg("22206C").GetAwaiter().GetResult() 
                as OkNegotiatedContentResult<AlignRollerBrg>;

            Assert.IsNotNull(result);
        }
    }
}