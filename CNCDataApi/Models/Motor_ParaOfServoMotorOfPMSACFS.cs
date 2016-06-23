namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table(name: "Motor_ParaOfServoMotorOfPMSACFS")]
    public partial class PMSrvMotorPara
    {
        [Key]
        [StringLength(50)]
        public string TypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Manufacturer { get; set; }

        public double? RatedTorque { get; set; }

        public double? MaxTorque { get; set; }

        public int? RatedRotationSpeed { get; set; }

        public int? MaxRotationSpeed { get; set; }

        public double? MomentOfInertia { get; set; }

        public double? RatedPower { get; set; }

        public double? StaticTorque { get; set; }

        public int? PairsOfMotorPole { get; set; }

        public double? DCLinkVoltage { get; set; }

        public double? RatedCurrent { get; set; }

        public double? MaxCurrent { get; set; }

        public double? MechanicalTimeConstant { get; set; }

        public double? Mass { get; set; }

        public double? StatorResistance { get; set; }

        public double? LeakageInductanceOfEachPhaseOfStatorWinding { get; set; }

        public double? CounterElectromotiveForce { get; set; }

        public int? RatedFrequency { get; set; }

        public double? MomentOfInertiaOfMotorRotor { get; set; }

        public double? ResistanceOfPhaseWinding { get; set; }

        public double? InductanceOfPhaseWinding { get; set; }

        [StringLength(10)]
        public string IfWithBrake { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }
    }
}
