using Microsoft.VisualStudio.TestTools.UnitTesting;
using CNCDataManager.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNCDataManager.Models;
using System.Web.Http.Results;

namespace CNCDataManager.Controllers.Tests
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