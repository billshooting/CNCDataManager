namespace CNCDataApi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CNCMachineData : DbContext
    {
        public CNCMachineData() : base("name=CNCMachineData") { }

        public virtual DbSet<NCSystem>                      NCSystems                           { get; set; }
        public virtual DbSet<StepMotorSize>                 StepMotorSizes                      { get; set; }
        public virtual DbSet<StepMotorPara>                 StepMotorParas                      { get; set; }
        public virtual DbSet<GearCoup>                      GearCouplings                       { get; set; }
        public virtual DbSet<BWElasticSlvPinCoup>           BWElasticSlvPinCouplings            { get; set; }
        public virtual DbSet<ElasticSlvPinCoup>             ElasticSlvPinCouplings              { get; set; }
        public virtual DbSet<FlexiblePinCoup>               FlexiblePinCouplings                { get; set; }
        public virtual DbSet<Cables>                        Cables                              { get; set; }
        public virtual DbSet<ElecSpindleSize>               ElecSpindleSizes                    { get; set; }
        public virtual DbSet<ElecSpindlePara>               ElecSpindleParas                    { get; set; }
        public virtual DbSet<NeedleRollerThrustRollerBrg>   NeedleRollerThrustRollerBearings    { get; set; }
        public virtual DbSet<BallLeadScrewSptBrg>           BallLeadScrewSptBearings            { get; set; }
        public virtual DbSet<RotaryTable>                   RotaryTables                        { get; set; }
        public virtual DbSet<XTaperedRollerBrg>             XTaperedRollerBearings              { get; set; }
        public virtual DbSet<AngContactBallBrg>             AngContactBallBearings              { get; set; }
        public virtual DbSet<HubShapedCoup>                 HubShapedCouplings                  { get; set; }
        public virtual DbSet<PlumShapedFlexibleCoup>        PlumShapedFlexibleCouplings         { get; set; }
        public virtual DbSet<CommonCylinWormGear>           CommonCylinWormGears                { get; set; }
        public virtual DbSet<DeepGrooveBallBrg>             DeepGrooveBallBearings              { get; set; }
        public virtual DbSet<OldhamCoup>                    OldhamCouplings                     { get; set; }
        public virtual DbSet<SolidBallScrewNutPairs>        SolidBallScrewNutPairs              { get; set; }
        public virtual DbSet<NCSystemIOUnit>                NCSystemIOUnits                     { get; set; }
        public virtual DbSet<NCSystemPowerUnit>             NCSystemPowerUnits                  { get; set; }
        public virtual DbSet<NCSystemFunctionalOptions>     NCSystemFunctionalOptions           { get; set; }
        public virtual DbSet<NCSystemManual>                NCSystemManuals                     { get; set; }
        public virtual DbSet<DoubleRowCylinRollerBrg>       DoubleRowCylinRollerBearings        { get; set; }
        public virtual DbSet<DoubleThrustAngContactBallBrg> DoubleThrustAngContactBallBearings  { get; set; }
        public virtual DbSet<SrvDriverReactor>              SrvDriverReactors                   { get; set; }
        public virtual DbSet<SrvDriverTransformer>          SrvDriverTransformers               { get; set; }
        public virtual DbSet<SrvDriverBrakeResistor>        SrvDriverBrakeResistors             { get; set; }
        public virtual DbSet<AlignRollerBrg>                AlignRollerBearings                 { get; set; }
        public virtual DbSet<AlignBallBrg>                  AlignBallBearings                   { get; set; }
        public virtual DbSet<FlangeCoup>                    FlangeCouplings                     { get; set; }
        public virtual DbSet<HeliCylinGear>                 HeliCylinGears                      { get; set; }
        public virtual DbSet<PMSrvMotorSize>                PMSrvMotorSizes                     { get; set; }
        public virtual DbSet<PMSrvMotorPara>                PMSrvMotorParas                     { get; set; }
        public virtual DbSet<PMSrvMotorDriver>              PMSrvMotorDrivers                   { get; set; }
        public virtual DbSet<ArcCylinWormGear>              ArcCylinWormGears                   { get; set; }
        public virtual DbSet<CylinRollerBrg>                CylinRollerBearings                 { get; set; }
        public virtual DbSet<TaperedRollerBrg>              TaperedRollerBearings               { get; set; }
        public virtual DbSet<SpurGear>                      SpurGears                           { get; set; }
        public virtual DbSet<StraightBevelGear>             StraightBevelGears                  { get; set; }
        public virtual DbSet<LineRollingGuide>              LineRollingGuides                   { get; set; }
        public virtual DbSet<SpindleBeltSize>               SpindleBeltSizes                    { get; set; }
        public virtual DbSet<SpindleBeltLength>             SpindleBeltLengths                  { get; set; }
        public virtual DbSet<SpindleBeltPara>               SpindleBeltParas                    { get; set; }
        public virtual DbSet<SpindleSrvMotorSize>           SpindleSrvMotorSizes                { get; set; }
        public virtual DbSet<SpindleSrvMotorPara>           SpindleSrvMotorParas                { get; set; }
        public virtual DbSet<SpindleSrvMotorDriver>         SpindleSrvMotorDrivers              { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StepMotorPara>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<StepMotorPara>()
                .HasOptional(e => e.SizeOfStepMotor)
                .WithRequired(e => e.ParaOfStepMotor);

            modelBuilder.Entity<GearCoup>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<BWElasticSlvPinCoup>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ElasticSlvPinCoup>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<FlexiblePinCoup>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ElecSpindlePara>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ElecSpindlePara>()
                .HasOptional(e => e.SizeOfElecSpindle)
                .WithRequired(e => e.ParaOfElectricSpindle);

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

            modelBuilder.Entity<PlumShapedFlexibleCoup>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<CommonCylinWormGear>()
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

            modelBuilder.Entity<OldhamCoup>()
                .Property(e => e.Description)
                .IsUnicode(false);

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

            modelBuilder.Entity<FlangeCoup>()
                .Property(e => e.DiameterOfBolts)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FlangeCoup>()
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

            modelBuilder.Entity<PMSrvMotorSize>()
                .Property(e => e.Size_F)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PMSrvMotorSize>()
                .Property(e => e.Size_D)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PMSrvMotorPara>()
                .Property(e => e.IfWithBrake)
                .IsFixedLength();

            modelBuilder.Entity<PMSrvMotorPara>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<PMSrvMotorPara>()
                .HasOptional(e => e.SizeOfPMSrvMotor)
                .WithRequired(e => e.ParaOfPMSrvMotor);

            modelBuilder.Entity<PMSrvMotorDriver>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ArcCylinWormGear>()
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

            modelBuilder.Entity<SpindleBeltSize>()
                .Property(e => e.TypeID)
                .IsUnicode(false);

            modelBuilder.Entity<SpindleBeltSize>()
                .Property(e => e.C2F)
                .IsUnicode(false);

            modelBuilder.Entity<SpindleBeltPara>()
                .Property(e => e.BeltType)
                .IsUnicode(false);

            modelBuilder.Entity<SpindleBeltPara>()
                .Property(e => e.BeltWidth)
                .IsFixedLength();

            modelBuilder.Entity<SpindleSrvMotorPara>()
                .Property(e => e.MaxRotationSpeed)
                .IsUnicode(false);

            modelBuilder.Entity<SpindleSrvMotorPara>()
                .Property(e => e.Description)
                .IsUnicode(false);
        }
    }
}
