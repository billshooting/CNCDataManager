using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Web.Http.Results;
using CNCDataManager.APIs.Controllers;
using CNCDataManager.APIs.Models;

namespace CNCDataManager.APIs.Tests
{
    [TestClass()]
    public class BallLeadScrewSptBrgsControllerTests
    {
        [TestMethod()]
        public void GetBallLeadScrewSptBearingsTest()
        {
            var controller = new BallLeadScrewSptBrgsController();
            int expected = 1;

            var result = controller.GetBallLeadScrewSptBearings();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());

        }

        [TestMethod()]
        public void GetBallLeadScrewSptBrgTest()
        {
            var con = new BallLeadScrewSptBrgsController();

            var result = con.GetBallLeadScrewSptBrg("15TAB04").GetAwaiter().GetResult() 
                as OkNegotiatedContentResult<BallLeadScrewSptBrg>;

            Assert.IsNotNull(result);
        }
    }
}