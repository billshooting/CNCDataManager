using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNCDataManager.Models;
using CNCDataManager.Controllers.Internals;
using System.Threading;
using System.Globalization;

namespace CNCDataManager.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        [HttpPost]
        public ActionResult Index (SelectionResult selectionResult)
        {
            ReportTemplateResult result = ToReportTemplate(selectionResult);
            string shortName = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + ".docx";
            string filename = HttpContext.Server.MapPath(@"~/App/temp/") + shortName;
            result.Filename = shortName;
            //using (DocxGenerator gen = new DocxGenerator(HttpContext.Server.MapPath(@"~/App/docTemplate/选型简表结果.docx")))
            //{
            //    gen.AddMachinePicture(MapPath(result.MachinePicture))
            //        .AddSimulationPictures(MapPath(result.SimulationPictures.ToArray()))
            //        .AddContent(result)
            //        .SaveAs(filename);
            //}
            //return View(result);
            return View("test");
        }

        private ReportTemplateResult ToReportTemplate(SelectionResult result)
        {
            ReportTemplateResult res = new ReportTemplateResult()
            {
                MachinePicture = "../App/images/Upload/MachineType.png",
                TransmissionMethod = new TransmissionMethod()
                {
                    XAxis = "减速器",
                    YAxis = "联轴器",
                    ZAxis = "带传动"
                },
                Components = new List<Component>(),
                NCSystem = result.NCSystem,
                ServoMotor = new ServoMotor(),
                ServoDriver = new ServoDriver(),
                Guide = new Guide(),
                BallScrew = new BallScrew(),
                SimulationPictures = new List<string>()
                {
                    "../App/images/Upload/simu-1.png",
                    "../App/images/Upload/simu-2.png",
                    "../App/images/Upload/simu-3.png"
                }
            };
            res.Components.Add(new Component() { AxisAndName = "X轴滚珠丝杠", TypeID = result.FeedSystemX.Ballscrew.TypeID, Manufacturer = result.FeedSystemX.Ballscrew.Manufacturer });
            res.Components.Add(new Component() { AxisAndName = "X轴轴承", TypeID = result.FeedSystemX.Bearings.TypeID, Manufacturer = result.FeedSystemX.Bearings.Manufacturer });
            res.Components.Add(new Component() { AxisAndName = "X轴联轴器", TypeID = result.FeedSystemX.Coupling.TypeID, Manufacturer = result.FeedSystemX.Coupling.Manufacturer });
            res.Components.Add(new Component() { AxisAndName = "X轴伺服驱动", TypeID = result.FeedSystemX.Driver.TypeID, Manufacturer = result.FeedSystemX.Driver.Manufacturer });
            res.Components.Add(new Component() { AxisAndName = "X轴伺服电机", TypeID = result.FeedSystemX.ServoMotor.TypeID, Manufacturer = result.FeedSystemX.ServoMotor.Manufacturer });
            res.Components.Add(new Component() { AxisAndName = "X轴导轨", TypeID = result.FeedSystemX.Guide.TypeID, Manufacturer = result.FeedSystemX.Guide.Manufacturer });
            res.Components.Add(new Component() { AxisAndName = "Y轴滚珠丝杠", TypeID = result.FeedSystemY.Ballscrew.TypeID, Manufacturer = result.FeedSystemY.Ballscrew.Manufacturer });
            res.Components.Add(new Component() { AxisAndName = "Y轴轴承", TypeID = result.FeedSystemY.Bearings.TypeID, Manufacturer = result.FeedSystemY.Bearings.Manufacturer });
            res.Components.Add(new Component() { AxisAndName = "Y轴联轴器", TypeID = result.FeedSystemY.Coupling.TypeID, Manufacturer = result.FeedSystemY.Coupling.Manufacturer });
            res.Components.Add(new Component() { AxisAndName = "Y轴伺服驱动", TypeID = result.FeedSystemY.Driver.TypeID, Manufacturer = result.FeedSystemY.Driver.Manufacturer });
            res.Components.Add(new Component() { AxisAndName = "Y轴伺服电机", TypeID = result.FeedSystemY.ServoMotor.TypeID, Manufacturer = result.FeedSystemY.ServoMotor.Manufacturer });
            res.Components.Add(new Component() { AxisAndName = "Y轴导轨", TypeID = result.FeedSystemY.Guide.TypeID, Manufacturer = result.FeedSystemY.Guide.Manufacturer });
            res.Components.Add(new Component() { AxisAndName = "Z轴滚珠丝杠", TypeID = result.FeedSystemZ.Ballscrew.TypeID, Manufacturer = result.FeedSystemZ.Ballscrew.Manufacturer });
            res.Components.Add(new Component() { AxisAndName = "Z轴轴承", TypeID = result.FeedSystemZ.Bearings.TypeID, Manufacturer = result.FeedSystemZ.Bearings.Manufacturer });
            res.Components.Add(new Component() { AxisAndName = "Z轴联轴器", TypeID = result.FeedSystemZ.Coupling.TypeID, Manufacturer = result.FeedSystemZ.Coupling.Manufacturer });
            res.Components.Add(new Component() { AxisAndName = "Z轴伺服驱动", TypeID = result.FeedSystemZ.Driver.TypeID, Manufacturer = result.FeedSystemZ.Driver.Manufacturer });
            res.Components.Add(new Component() { AxisAndName = "Z轴伺服电机", TypeID = result.FeedSystemZ.ServoMotor.TypeID, Manufacturer = result.FeedSystemZ.ServoMotor.Manufacturer });
            res.Components.Add(new Component() { AxisAndName = "Z轴导轨", TypeID = result.FeedSystemZ.Guide.TypeID, Manufacturer = result.FeedSystemZ.Guide.Manufacturer });

            return res;
        }

        public void DownLoad(string shortName)
        {
            Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            string filename = HttpContext.Server.MapPath(@"~/App/temp/") + shortName;
            Response.WriteFile(filename);
            
        }

        private string MapPath(string relativeUrl)
        {
            return HttpContext.Server.MapPath(relativeUrl.Replace("..", "~"));
        }

        private string[] MapPath(string[] relativeUrls)
        {
            return new string[]
            {
                MapPath(relativeUrls[0]),
                MapPath(relativeUrls[1]),
                MapPath(relativeUrls[2])
            };
        }
    }
}