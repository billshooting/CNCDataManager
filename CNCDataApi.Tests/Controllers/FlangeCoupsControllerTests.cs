using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataApi.Models;
using System.Web.Http.Results;

namespace CNCDataApi.Controllers.Tests
{
    [TestClass()]
    public class FlangeCoupsControllerTests
    {
        [TestMethod()]
        public void GetFlangeCouplingsTest()
        {
            var con = new FlangeCoupsController();
            int expected = 18;

            var result = con.GetFlangeCouplings();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetFlangeCoupTest()
        {
            var con = new FlangeCoupsController();

            var result = con.GetFlangeCoup("YL10").GetAwaiter().GetResult() 
                as OkNegotiatedContentResult<FlangeCoup>;

            Assert.IsNotNull(result);
        }
    }
}