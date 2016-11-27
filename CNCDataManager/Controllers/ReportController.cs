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
        public ActionResult Index ()
        {
            SelectionResult result = new SelectionResult()
            {
                MachinePicture = "../App/images/Upload/MachineType.png",
                TransmissionMethod = new TransmissionMethod()
                {
                    XAxis = "减速器",
                    YAxis = "联轴器",
                    ZAxis = "带传动"
                },
                Components = new List<Component>()
                {
                    new Component() { AxisAndName = "进给轴轴承", Manufacturer = "洛阳轴承厂", TypeID = "LZ001C"}
                },
                NCSystem = new NCSystem()
                {
                    TypeID = "HCN808",
                    SupportMachineType = "铣床",
                    NumberOfSupportChannels = 4,
                    MaxNumberOfFeedSystemAxis = 1,
                    MaxNumberOfSpindleAxis = 2,
                    MaxNumberOfLinkageAxis = 4
                },
                ServoMotor = new ServoMotor()
                {
                    XAxis = new ServoMotorAxis() { RatedTorque = 100, RatedSpeed = 3600, MomentOfInertia = 100, RatedPower = 5},
                    YAxis = new ServoMotorAxis() { RatedTorque = 100, RatedSpeed = 3600, MomentOfInertia = 100, RatedPower = 5},
                    ZAxis = new ServoMotorAxis() { RatedTorque = 100, RatedSpeed = 3600, MomentOfInertia = 100, RatedPower = 5}
                },
                ServoDriver = new ServoDriver()
                {
                    XAxis = new ServoDriverAxis() { ContinuousCurrent = 5, PeakCurrent = 15, SupplyVoltage = 380, MaxAdaptableMotorPower = 10, ExternalBrakingResistance = 1000},
                    YAxis = new ServoDriverAxis() { ContinuousCurrent = 5, PeakCurrent = 15, SupplyVoltage = 380, MaxAdaptableMotorPower = 10, ExternalBrakingResistance = 1000},
                    ZAxis = new ServoDriverAxis() { ContinuousCurrent = 5, PeakCurrent = 15, SupplyVoltage = 380, MaxAdaptableMotorPower = 10, ExternalBrakingResistance = 1000}
                },
                Guide = new Guide()
                {
                    XAxis = new GuideAxis() { SizeOfGuideFixedBolt = "10", RollerType = "钢珠", BasicRatedStaticLoad = 10, BasicRatedDynamicLoad = 5},
                    YAxis = new GuideAxis() { SizeOfGuideFixedBolt = "10", RollerType = "钢珠", BasicRatedStaticLoad = 10, BasicRatedDynamicLoad = 5},
                    ZAxis = new GuideAxis() { SizeOfGuideFixedBolt = "10", RollerType = "钢珠", BasicRatedStaticLoad = 10, BasicRatedDynamicLoad = 5}
                },
                BallScrew = new BallScrew()
                {
                    XAxis = new BallScrewAxis() { NominalDiameter = 10, NominalLead = 1000, BasicRatedDynamicLoad = 10},
                    YAxis = new BallScrewAxis() { NominalDiameter = 10, NominalLead = 1000, BasicRatedDynamicLoad = 10},
                    ZAxis = new BallScrewAxis() { NominalDiameter = 10, NominalLead = 1000, BasicRatedDynamicLoad = 10}
                },
                SimulationPictures = new List<string>()
                {
                    "../App/images/Upload/simu-1.png",
                    "../App/images/Upload/simu-2.png",
                    "../App/images/Upload/simu-3.png"
                }
            };
            return View(result);
        }

        public void DownLoad()
        {
            SelectionResult result = new SelectionResult()
            {
                MachinePicture = "../App/images/Upload/MachineType.png",
                TransmissionMethod = new TransmissionMethod()
                {
                    XAxis = "减速器",
                    YAxis = "联轴器",
                    ZAxis = "带传动"
                },
                Components = new List<Component>()
                {
                    new Component() { AxisAndName = "进给轴轴承", Manufacturer = "洛阳轴承厂", TypeID = "LZ001C"}
                },
                NCSystem = new NCSystem()
                {
                    TypeID = "HCN808",
                    SupportMachineType = "铣床",
                    NumberOfSupportChannels = 4,
                    MaxNumberOfFeedSystemAxis = 1,
                    MaxNumberOfSpindleAxis = 2,
                    MaxNumberOfLinkageAxis = 4
                },
                ServoMotor = new ServoMotor()
                {
                    XAxis = new ServoMotorAxis() { RatedTorque = 100, RatedSpeed = 3600, MomentOfInertia = 100, RatedPower = 5 },
                    YAxis = new ServoMotorAxis() { RatedTorque = 100, RatedSpeed = 3600, MomentOfInertia = 100, RatedPower = 5 },
                    ZAxis = new ServoMotorAxis() { RatedTorque = 100, RatedSpeed = 3600, MomentOfInertia = 100, RatedPower = 5 }
                },
                ServoDriver = new ServoDriver()
                {
                    XAxis = new ServoDriverAxis() { ContinuousCurrent = 5, PeakCurrent = 15, SupplyVoltage = 380, MaxAdaptableMotorPower = 10, ExternalBrakingResistance = 1000 },
                    YAxis = new ServoDriverAxis() { ContinuousCurrent = 5, PeakCurrent = 15, SupplyVoltage = 380, MaxAdaptableMotorPower = 10, ExternalBrakingResistance = 1000 },
                    ZAxis = new ServoDriverAxis() { ContinuousCurrent = 5, PeakCurrent = 15, SupplyVoltage = 380, MaxAdaptableMotorPower = 10, ExternalBrakingResistance = 1000 }
                },
                Guide = new Guide()
                {
                    XAxis = new GuideAxis() { SizeOfGuideFixedBolt = "10", RollerType = "钢珠", BasicRatedStaticLoad = 10, BasicRatedDynamicLoad = 5 },
                    YAxis = new GuideAxis() { SizeOfGuideFixedBolt = "10", RollerType = "钢珠", BasicRatedStaticLoad = 10, BasicRatedDynamicLoad = 5 },
                    ZAxis = new GuideAxis() { SizeOfGuideFixedBolt = "10", RollerType = "钢珠", BasicRatedStaticLoad = 10, BasicRatedDynamicLoad = 5 }
                },
                BallScrew = new BallScrew()
                {
                    XAxis = new BallScrewAxis() { NominalDiameter = 10, NominalLead = 1000, BasicRatedDynamicLoad = 10 },
                    YAxis = new BallScrewAxis() { NominalDiameter = 10, NominalLead = 1000, BasicRatedDynamicLoad = 10 },
                    ZAxis = new BallScrewAxis() { NominalDiameter = 10, NominalLead = 1000, BasicRatedDynamicLoad = 10 }
                },
                SimulationPictures = new List<string>()
                {
                    "../App/images/Upload/simu-1.png",
                    "../App/images/Upload/simu-2.png",
                    "../App/images/Upload/simu-3.png"
                }
            };
            string filename = HttpContext.Server.MapPath(@"~/App/temp/") + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + ".docx";
            using (DocxGenerator gen = new DocxGenerator(HttpContext.Server.MapPath(@"~/App/docTemplate/选型简表结果.docx")))
            {
                gen.AddMachinePicture(MapPath(result.MachinePicture))
                    .AddSimulationPictures(MapPath(result.SimulationPictures.ToArray()))
                    .AddContent(result)
                    .SaveAs(filename);
            }
            Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
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