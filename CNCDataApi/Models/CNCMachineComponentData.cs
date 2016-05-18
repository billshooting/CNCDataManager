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

        public virtual DbSet<Bearings_AligningBallBearings> Bearings_AligningBallBearings { get; set; }
        public virtual DbSet<Bearings_AligningRollerBearing> Bearings_AligningRollerBearing { get; set; }
        public virtual DbSet<Bearings_AngularContactBallBearings> Bearings_AngularContactBallBearings { get; set; }
        public virtual DbSet<Bearings_BallLeadScrewSupportBearings> Bearings_BallLeadScrewSupportBearings { get; set; }
        public virtual DbSet<Bearings_CrossTaperedRollerBearings> Bearings_CrossTaperedRollerBearings { get; set; }
        public virtual DbSet<Bearings_CylindricalRollerBearings> Bearings_CylindricalRollerBearings { get; set; }
        public virtual DbSet<Bearings_DeepGrooveBallBearings> Bearings_DeepGrooveBallBearings { get; set; }
        public virtual DbSet<Bearings_DoubleRowCylindricalRollerBearings> Bearings_DoubleRowCylindricalRollerBearings { get; set; }
        public virtual DbSet<Bearings_DoubleThrustAngularContactBallBearings> Bearings_DoubleThrustAngularContactBallBearings { get; set; }
        public virtual DbSet<Bearings_NeedleRollerAndThrustRollerBearings> Bearings_NeedleRollerAndThrustRollerBearings { get; set; }
        public virtual DbSet<Bearings_TaperedRollerBearings> Bearings_TaperedRollerBearings { get; set; }
        public virtual DbSet<Coupling_BrakeWheelElasticSleevePinCoupling> Coupling_BrakeWheelElasticSleevePinCoupling { get; set; }
        public virtual DbSet<Coupling_ElasticSleevePinCoupling> Coupling_ElasticSleevePinCoupling { get; set; }
        public virtual DbSet<Coupling_FlangeCoupling> Coupling_FlangeCoupling { get; set; }
        public virtual DbSet<Coupling_FlexiblePinCoupling> Coupling_FlexiblePinCoupling { get; set; }
        public virtual DbSet<Coupling_GearCoupling> Coupling_GearCoupling { get; set; }
        public virtual DbSet<Coupling_HubShapedCouplings> Coupling_HubShapedCouplings { get; set; }
        public virtual DbSet<Coupling_OldhamCoupling> Coupling_OldhamCoupling { get; set; }
        public virtual DbSet<Coupling_PlumShapedFlexibleCoupling> Coupling_PlumShapedFlexibleCoupling { get; set; }
        public virtual DbSet<Driver_DriverOfServoMotorOfPMSACFS> Driver_DriverOfServoMotorOfPMSACFS { get; set; }
        public virtual DbSet<Gear_HelicalCylindricalGear> Gear_HelicalCylindricalGear { get; set; }
        public virtual DbSet<Gear_SpurGear> Gear_SpurGear { get; set; }
        public virtual DbSet<Gear_StraightBevelGear_> Gear_StraightBevelGear_ { get; set; }
        public virtual DbSet<Guide_LinearRollingGuide> Guide_LinearRollingGuide { get; set; }
        public virtual DbSet<Motor_ParaOfElectricSpindle> Motor_ParaOfElectricSpindle { get; set; }
        public virtual DbSet<Motor_ParaOfServoMotorOfPMSACFS> Motor_ParaOfServoMotorOfPMSACFS { get; set; }
        public virtual DbSet<Motor_ParaOfServoMotorOfSpindle> Motor_ParaOfServoMotorOfSpindle { get; set; }
        public virtual DbSet<Motor_ParaOfStepperMotor> Motor_ParaOfStepperMotor { get; set; }
        public virtual DbSet<Motor_SizeOfElectricSpindle> Motor_SizeOfElectricSpindle { get; set; }
        public virtual DbSet<Motor_SizeOfServoMotorOfPMSACFS> Motor_SizeOfServoMotorOfPMSACFS { get; set; }
        public virtual DbSet<Motor_SizeOfServoMotorOfSpindle> Motor_SizeOfServoMotorOfSpindle { get; set; }
        public virtual DbSet<Motor_SizeOfStepperMotor> Motor_SizeOfStepperMotor { get; set; }
        public virtual DbSet<NutPairs_SolidBallScrewNutPairs> NutPairs_SolidBallScrewNutPairs { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<System_NCSystem> System_NCSystem { get; set; }
        public virtual DbSet<Table_RotaryTable> Table_RotaryTable { get; set; }
        public virtual DbSet<Worm_ArcCylindricalWormGear> Worm_ArcCylindricalWormGear { get; set; }
        public virtual DbSet<Worm_CommonCylindricalWormGear> Worm_CommonCylindricalWormGear { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bearings_AligningBallBearings>()
                .Property(e => e.TypeNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bearings_AligningBallBearings>()
                .Property(e => e.Manufacturer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bearings_AligningBallBearings>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Bearings_AligningRollerBearing>()
                .Property(e => e.TypeNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bearings_AligningRollerBearing>()
                .Property(e => e.Manufacturer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bearings_AligningRollerBearing>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Bearings_AngularContactBallBearings>()
                .Property(e => e.TypeNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bearings_AngularContactBallBearings>()
                .Property(e => e.Manufacturer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bearings_AngularContactBallBearings>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Bearings_BallLeadScrewSupportBearings>()
                .Property(e => e.TypeNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bearings_BallLeadScrewSupportBearings>()
                .Property(e => e.Manufacturer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bearings_BallLeadScrewSupportBearings>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Bearings_CrossTaperedRollerBearings>()
                .Property(e => e.TypeNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bearings_CrossTaperedRollerBearings>()
                .Property(e => e.Manufacturer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bearings_CrossTaperedRollerBearings>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Bearings_CylindricalRollerBearings>()
                .Property(e => e.TypeNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bearings_CylindricalRollerBearings>()
                .Property(e => e.Manufacturer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bearings_CylindricalRollerBearings>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Bearings_DeepGrooveBallBearings>()
                .Property(e => e.TypeNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bearings_DeepGrooveBallBearings>()
                .Property(e => e.Manufacturer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bearings_DeepGrooveBallBearings>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Bearings_DoubleRowCylindricalRollerBearings>()
                .Property(e => e.TypeNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bearings_DoubleRowCylindricalRollerBearings>()
                .Property(e => e.Manufacturer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bearings_DoubleRowCylindricalRollerBearings>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Bearings_DoubleThrustAngularContactBallBearings>()
                .Property(e => e.TypeNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bearings_DoubleThrustAngularContactBallBearings>()
                .Property(e => e.Manufacturer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bearings_DoubleThrustAngularContactBallBearings>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Bearings_NeedleRollerAndThrustRollerBearings>()
                .Property(e => e.TypeNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bearings_NeedleRollerAndThrustRollerBearings>()
                .Property(e => e.Manufacturer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bearings_NeedleRollerAndThrustRollerBearings>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Bearings_TaperedRollerBearings>()
                .Property(e => e.TypeNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bearings_TaperedRollerBearings>()
                .Property(e => e.Manufacturer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bearings_TaperedRollerBearings>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Coupling_BrakeWheelElasticSleevePinCoupling>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Coupling_ElasticSleevePinCoupling>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Coupling_FlangeCoupling>()
                .Property(e => e.DiameterOfBolts)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Coupling_FlangeCoupling>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Coupling_FlexiblePinCoupling>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Coupling_GearCoupling>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Coupling_HubShapedCouplings>()
                .Property(e => e.TypeNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Coupling_HubShapedCouplings>()
                .Property(e => e.Manufacturer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Coupling_HubShapedCouplings>()
                .Property(e => e.DiameterOfShaftHole_d1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Coupling_HubShapedCouplings>()
                .Property(e => e.DiameterOfShaftHole_d2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Coupling_HubShapedCouplings>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Coupling_OldhamCoupling>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Coupling_PlumShapedFlexibleCoupling>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Driver_DriverOfServoMotorOfPMSACFS>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Gear_HelicalCylindricalGear>()
                .Property(e => e.TypeNo)
                .IsFixedLength();

            modelBuilder.Entity<Gear_HelicalCylindricalGear>()
                .Property(e => e.Manufacturer)
                .IsFixedLength();

            modelBuilder.Entity<Gear_HelicalCylindricalGear>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Gear_SpurGear>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Gear_StraightBevelGear_>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Guide_LinearRollingGuide>()
                .Property(e => e.TypeNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Guide_LinearRollingGuide>()
                .Property(e => e.Manufacturer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Guide_LinearRollingGuide>()
                .Property(e => e.SizeOfGuideFixedBolt)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Guide_LinearRollingGuide>()
                .Property(e => e.RollerType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Guide_LinearRollingGuide>()
                .Property(e => e.SizeOfSlider_K)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Guide_LinearRollingGuide>()
                .Property(e => e.SizeOfSlider_M)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Guide_LinearRollingGuide>()
                .Property(e => e.SizeOfSlider_T2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Guide_LinearRollingGuide>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Motor_ParaOfElectricSpindle>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Motor_ParaOfServoMotorOfPMSACFS>()
                .Property(e => e.IfWithBrake)
                .IsFixedLength();

            modelBuilder.Entity<Motor_ParaOfServoMotorOfPMSACFS>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Motor_ParaOfServoMotorOfPMSACFS>()
                .HasOptional(e => e.Motor_SizeOfServoMotorOfPMSACFS)
                .WithRequired(e => e.Motor_ParaOfServoMotorOfPMSACFS);

            modelBuilder.Entity<Motor_ParaOfServoMotorOfSpindle>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Motor_ParaOfStepperMotor>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Motor_SizeOfElectricSpindle>()
                .HasOptional(e => e.Motor_ParaOfElectricSpindle)
                .WithRequired(e => e.Motor_SizeOfElectricSpindle);

            modelBuilder.Entity<Motor_SizeOfServoMotorOfPMSACFS>()
                .Property(e => e.Size_F)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Motor_SizeOfServoMotorOfPMSACFS>()
                .Property(e => e.Size_D)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Motor_SizeOfServoMotorOfSpindle>()
                .HasOptional(e => e.Motor_ParaOfServoMotorOfSpindle)
                .WithRequired(e => e.Motor_SizeOfServoMotorOfSpindle);

            modelBuilder.Entity<Motor_SizeOfStepperMotor>()
                .HasOptional(e => e.Motor_ParaOfStepperMotor)
                .WithRequired(e => e.Motor_SizeOfStepperMotor);

            modelBuilder.Entity<NutPairs_SolidBallScrewNutPairs>()
                .Property(e => e.TypeNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NutPairs_SolidBallScrewNutPairs>()
                .Property(e => e.Manufacturer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NutPairs_SolidBallScrewNutPairs>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Table_RotaryTable>()
                .Property(e => e.TypeNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Table_RotaryTable>()
                .Property(e => e.Manufacturer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Table_RotaryTable>()
                .Property(e => e.SizeOfWorkingTable)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Table_RotaryTable>()
                .Property(e => e.SizeOfCentrallyLocatedHole)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Table_RotaryTable>()
                .Property(e => e.TotalDriveRatio)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Table_RotaryTable>()
                .Property(e => e.PitchAccuracy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Table_RotaryTable>()
                .Property(e => e.RepeatAccuracy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Table_RotaryTable>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Worm_ArcCylindricalWormGear>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Worm_CommonCylindricalWormGear>()
                .Property(e => e.Description)
                .IsUnicode(false);
        }
    }
}
