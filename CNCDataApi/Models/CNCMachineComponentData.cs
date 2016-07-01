namespace CNCDataApi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CNCMachineComponentData : DbContext
    {
        public CNCMachineComponentData()
            : base("name=CNCMachineComponentData")
        {
        }

        public virtual DbSet<AlignBallBrg>                      AligningBallBearings                { get; set; }
        public virtual DbSet<AlignRollerBrg>                    AligningRollerBearing               { get; set; }
        public virtual DbSet<AngContactBallBrg>                 AngularContactBallBearings          { get; set; }
        public virtual DbSet<BallLeadScrewSptBrg>               BallLeadScrewSupportBearings        { get; set; }
        public virtual DbSet<XTaperedRollerBrg>                 CrossTaperedRollerBearings          { get; set; }
        public virtual DbSet<CylinRollerBrg>                    CylindricalRollerBearings           { get; set; }
        public virtual DbSet<DeepGrooveBallBrg>                 DeepGrooveBallBearings              { get; set; }
        public virtual DbSet<DoubleRowCylinRollerBrg>           DoubleRowCylindricalRollerBearings  { get; set; }
        public virtual DbSet<DoubleThrustAngContactBallBrg>     DoubleThrustAngularContactBallBearings { get; set; }
        public virtual DbSet<NeedleRollerThrustRollerBrg>       NeedleRollerAndThrustRollerBearings { get; set; }
        public virtual DbSet<TaperedRollerBrg>                  TaperedRollerBearings               { get; set; }
        public virtual DbSet<BWElasticSlvPinCoup>               BrakeWheelElasticSleevePinCoupling  { get; set; }
        public virtual DbSet<ElasticSlvPinCoup>                 ElasticSleevePinCoupling            { get; set; }
        public virtual DbSet<FlangeCoup>                        FlangeCoupling                      { get; set; }
        public virtual DbSet<FlexiblePinCoup>                   FlexiblePinCoupling                 { get; set; }
        public virtual DbSet<GearCoup>                          GearCoupling                        { get; set; }
        public virtual DbSet<HubShapedCoup>                     HubShapedCouplings                  { get; set; }
        public virtual DbSet<OldhamCoup>                        OldhamCoupling                      { get; set; }
        public virtual DbSet<PlumShapedFlexibleCoup>            PlumShapedFlexibleCoupling          { get; set; }
        public virtual DbSet<PMSrvMotorDriver>                  DriverOfServoMotorOfPMSACFS         { get; set; }
        public virtual DbSet<HeliCylinGear>                     HelicalCylindricalGear              { get; set; }
        public virtual DbSet<SpurGear>                          SpurGear                            { get; set; }
        public virtual DbSet<StraightBevelGear>                 StraightBevelGear                   { get; set; }
        public virtual DbSet<LineRollingGuide>                  LinearRollingGuide                  { get; set; }

        public virtual DbSet<ElecSpindlePara>                   ParaOfElectricSpindle               { get; set; }
        public virtual DbSet<PMSrvMotorPara>                    ParaOfServoMotorOfPMSACFS           { get; set; }
        public virtual DbSet<SpindleSrvMotorPara>               ParaOfServoMotorOfSpindle           { get; set; }
        public virtual DbSet<StepMotorPara>                     ParaOfStepperMotor                  { get; set; }
        public virtual DbSet<ElecSpindleSize>                   SizeOfElectricSpindle               { get; set; }
        public virtual DbSet<PMSrvMotorSize>                    SizeOfServoMotorOfPMSACFS           { get; set; }
        public virtual DbSet<SpindleSrvMotorSize>               SizeOfServoMotorOfSpindle           { get; set; }
        public virtual DbSet<StepMotorSize>                     SizeOfStepperMotor                  { get; set; }

        public virtual DbSet<SolidBallScrewNutPairs>            SolidBallScrewNutPairs              { get; set; }
        public virtual DbSet<NCSystem>                          NCSystem                            { get; set; }
        public virtual DbSet<RotaryTable>                       RotaryTable                         { get; set; }
        public virtual DbSet<ArcCylinWormGear>                  ArcCylindricalWormGear              { get; set; }
        public virtual DbSet<CommonCylinWormGear>               CommonCylindricalWormGear           { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlignBallBrg>()
                .Property(e => e.TypeID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AlignBallBrg>()
                .Property(e => e.Manufacturer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AlignBallBrg>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<AlignRollerBrg>()
                .Property(e => e.TypeID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AlignRollerBrg>()
                .Property(e => e.Manufacturer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AlignRollerBrg>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<AngContactBallBrg>()
                .Property(e => e.TypeID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AngContactBallBrg>()
                .Property(e => e.Manufacturer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AngContactBallBrg>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<BallLeadScrewSptBrg>()
                .Property(e => e.TypeID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BallLeadScrewSptBrg>()
                .Property(e => e.Manufacturer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BallLeadScrewSptBrg>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<XTaperedRollerBrg>()
                .Property(e => e.TypeID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<XTaperedRollerBrg>()
                .Property(e => e.Manufacturer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<XTaperedRollerBrg>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<CylinRollerBrg>()
                .Property(e => e.TypeID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CylinRollerBrg>()
                .Property(e => e.Manufacturer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CylinRollerBrg>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<DeepGrooveBallBrg>()
                .Property(e => e.TypeID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DeepGrooveBallBrg>()
                .Property(e => e.Manufacturer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DeepGrooveBallBrg>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<DoubleRowCylinRollerBrg>()
                .Property(e => e.TypeID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DoubleRowCylinRollerBrg>()
                .Property(e => e.Manufacturer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DoubleRowCylinRollerBrg>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<DoubleThrustAngContactBallBrg>()
                .Property(e => e.TypeID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DoubleThrustAngContactBallBrg>()
                .Property(e => e.Manufacturer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DoubleThrustAngContactBallBrg>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<NeedleRollerThrustRollerBrg>()
                .Property(e => e.TypeID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NeedleRollerThrustRollerBrg>()
                .Property(e => e.Manufacturer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NeedleRollerThrustRollerBrg>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<TaperedRollerBrg>()
                .Property(e => e.TypeID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TaperedRollerBrg>()
                .Property(e => e.Manufacturer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TaperedRollerBrg>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<BWElasticSlvPinCoup>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ElasticSlvPinCoup>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<FlangeCoup>()
                .Property(e => e.DiameterOfBolts)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FlangeCoup>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<FlexiblePinCoup>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<GearCoup>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<HubShapedCoup>()
                .Property(e => e.TypeID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HubShapedCoup>()
                .Property(e => e.Manufacturer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HubShapedCoup>()
                .Property(e => e.DiameterOfShaftHole_d1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HubShapedCoup>()
                .Property(e => e.DiameterOfShaftHole_d2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HubShapedCoup>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<OldhamCoup>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<PlumShapedFlexibleCoup>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<PMSrvMotorDriver>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<HeliCylinGear>()
                .Property(e => e.TypeID)
                .IsFixedLength();

            modelBuilder.Entity<HeliCylinGear>()
                .Property(e => e.Manufacturer)
                .IsFixedLength();

            modelBuilder.Entity<HeliCylinGear>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<SpurGear>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<StraightBevelGear>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<LineRollingGuide>()
                .Property(e => e.TypeID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LineRollingGuide>()
                .Property(e => e.Manufacturer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LineRollingGuide>()
                .Property(e => e.SizeOfGuideFixedBolt)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LineRollingGuide>()
                .Property(e => e.RollerType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LineRollingGuide>()
                .Property(e => e.SizeOfSlider_K)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LineRollingGuide>()
                .Property(e => e.SizeOfSlider_M)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LineRollingGuide>()
                .Property(e => e.SizeOfSlider_T2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LineRollingGuide>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ElecSpindlePara>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<PMSrvMotorPara>()
                .Property(e => e.IfWithBrake)
                .IsFixedLength();

            modelBuilder.Entity<PMSrvMotorPara>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<SpindleSrvMotorPara>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<StepMotorPara>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ElecSpindleSize>()
                .HasOptional(e => e.Motor_ParaOfElectricSpindle)
                .WithRequired(e => e.Motor_SizeOfElectricSpindle);

            modelBuilder.Entity<PMSrvMotorSize>()
                .Property(e => e.Size_F)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PMSrvMotorSize>()
                .Property(e => e.Size_D)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SpindleSrvMotorSize>()
                .HasOptional(e => e.Motor_ParaOfServoMotorOfSpindle)
                .WithRequired(e => e.Motor_SizeOfServoMotorOfSpindle);

            modelBuilder.Entity<StepMotorSize>()
                .HasOptional(e => e.Motor_ParaOfStepperMotor)
                .WithRequired(e => e.Motor_SizeOfStepperMotor);

            modelBuilder.Entity<SolidBallScrewNutPairs>()
                .Property(e => e.TypeID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SolidBallScrewNutPairs>()
                .Property(e => e.Manufacturer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SolidBallScrewNutPairs>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<RotaryTable>()
                .Property(e => e.TypeID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RotaryTable>()
                .Property(e => e.Manufacturer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RotaryTable>()
                .Property(e => e.SizeOfWorkingTable)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RotaryTable>()
                .Property(e => e.SizeOfCentrallyLocatedHole)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RotaryTable>()
                .Property(e => e.TotalDriveRatio)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RotaryTable>()
                .Property(e => e.PitchAccuracy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RotaryTable>()
                .Property(e => e.RepeatAccuracy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RotaryTable>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ArcCylinWormGear>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<CommonCylinWormGear>()
                .Property(e => e.Description)
                .IsUnicode(false);
        }
    }
}
