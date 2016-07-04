using Microsoft.VisualStudio.TestTools.UnitTesting;
using CNCDataApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNCDataApi.Models;
using System.Web.Http.Results;

namespace CNCDataApi.Controllers.Tests
{
    [TestClass()]
    public class AlignBallBrgsControllerTests
    {
        [TestMethod()]
        public void GetAlignBallBearingsTest()
        {
            //arrange
            var controller = new AlignBallBrgsController();
            int count = 11;
            //acr
            var result = controller.GetAlignBallBearings();
            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(count, result.Count());
        }

        [TestMethod()]
        public void GetAlignBallBrgTest()
        {
            var controller = new AlignBallBrgsController();

            var result = controller.GetAlignBallBrg("1204").GetAwaiter().GetResult() 
                as OkNegotiatedContentResult<AlignBallBrg>;

            Assert.IsNotNull(result);
        }
    }
}