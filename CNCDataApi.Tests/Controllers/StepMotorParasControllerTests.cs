﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Web.Http.Results;

namespace CNCDataManager.Controllers.Tests
{
    [TestClass()]
    public class StepMotorParasControllerTests
    {
        [TestMethod()]
        public void GetStepMotorParasTest()
        {
            var con = new StepMotorParasController();
            int expected = 0;

            var result = con.GetStepMotorParas();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod()]
        public void GetStepMotorParaTest()
        {
            var con = new StepMotorParasController();

            var result = con.GetStepMotorPara("1").GetAwaiter().GetResult()
                as NotFoundResult;

            Assert.IsNotNull(result);
        }
    }
}