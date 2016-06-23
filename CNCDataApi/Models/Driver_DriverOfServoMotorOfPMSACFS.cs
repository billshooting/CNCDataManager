namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table(name: "Driver_DriverOfServoMotorOfPMSACFS")]
    public partial class PMSrvMotorDrv
    {
        [Key]
        [StringLength(50)]
        public string TypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Manufacturer { get; set; }

        public double? ContinuousCurrent { get; set; }

        public double? PeakCurrent { get; set; }

        [StringLength(50)]
        public string SupplyVoltage { get; set; }

        public double? MaxAdaptableMotorPower { get; set; }

        public double? MaxBrakingCurrent { get; set; }

        [StringLength(50)]
        public string ExternalBrakingResistance { get; set; }

        public double? CycleOfPWM { get; set; }

        public double? SupplyVoltageOfDC { get; set; }

        public double? PositionLoopGain { get; set; }

        public double? SpeedLoopGain { get; set; }

        public double? IntegralConstantOfSpeedLoop { get; set; }

        public double? GainOfDaxisCurrent { get; set; }

        public double? IntegralConstantOfDaxisCurrent { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }
    }
}
