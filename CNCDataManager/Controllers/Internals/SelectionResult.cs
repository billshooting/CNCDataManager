using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNCDataManager.Controllers.Internals
{
    internal class TransmissionMethod
    {
        public string XAxis { get; set; }
        public string YAxis { get; set; }
        public string ZAxis { get; set; }
    }

    internal class Component
    {
        public string TypeID { get; set; }
        public string Manufacturer { get; set; }
        public string AxisAndName { get; set; }
    }

    internal class EssentialPart
    {
        public string CNCSystem { get; set; }
        public string MachineType { get; set; }
        public int? NumberOfChannels { get; set; }
        public int? MaxNumberOfFeedSystemAxis { get; set; }
        public int? MaxNumberOfSpindleAxis { get; set; }
        public int? MaxNumberOfLinkageAxis { get; set; }
    }
    internal class ServoMotorAxis
    {
        public double? RatedTorque { get; set; }
        public double? RatedSpeed { get; set; }
        public double? RatedPower { get; set; }
        public double? MomentOfInertia { get; set; }
    }
    internal class ServoMotor
    {
        public ServoMotorAxis XAxis { get; set; }
        public ServoMotorAxis YAxis { get; set; }
        public ServoMotorAxis ZAxis { get; set; }
    }

    internal class ServoDriverAxis
    {
        public double? ContinuousCurrent { get; set; }
        public double? PeakCurrent { get; set; }
        public double? SupplyVoltage { get; set; }
        public double? MaxAdaptableMotorPower { get; set; }
        public double? ExternalBrakingResistance { get; set; }
    }
    internal class ServoDriver
    {
        public ServoDriverAxis XAxis { get; set; }
        public ServoDriverAxis YAxis { get; set; }
        public ServoDriverAxis ZAxis { get; set; }
    }

    internal class GuideAxis
    {
        public string SizeOfGuideFixedBolt { get; set; }
        public string RollerType { get; set; }
        public double? BasicRatedDynamicLoad { get; set; }
        public double? BasicRatedStaticLoad { get; set; }
    }
    internal class Guide
    {
        public GuideAxis XAxis { get; set; }
        public GuideAxis YAxis { get; set; }
        public GuideAxis ZAxis { get; set; }
    }

    internal class BallScrewAxis
    {
        public double? NominalDiameter { get; set; }
        public double? NominalLead { get; set; }
        public double? BasicRatedDynamicLoad { get; set; }
    }
    internal class BallScrew
    {
        public BallScrewAxis XAxis { get; set; }
        public BallScrewAxis YAxis { get; set; }
        public BallScrewAxis ZAxis { get; set; }
    }
    internal class SelectionResult
    {
        public TransmissionMethod TransmissionMethod { get; set; }
        public List<Component> Components { get; set; }
        public EssentialPart EssentialPart { get; set; }
        public ServoMotor ServoMotor { get; set; }
        public ServoDriver ServoDriver { get; set; }
        public Guide Guide { get; set; }
        public BallScrew BallScrew { get; set; }
    }
}