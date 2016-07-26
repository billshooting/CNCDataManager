﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CNCDataManager.Models;
using System.Web.Http.Results;

namespace CNCDataManager.Controllers.Tests
{
    [TestClass()]
    public class SpurGearsControllerTests
    {
        [TestMethod()]
        public void GetSpurGearsTest()
        {
            var con = new SpurGearsController();
            int expected = 2;

            var result = con.GetSpurGears();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetSpurGearTest()
        {
            var con = new SpurGearsController();

            var result = con.GetSpurGear("1").GetAwaiter().GetResult()
                as OkNegotiatedContentResult<SpurGear>;

            Assert.IsNotNull(result);
        }
    }
}