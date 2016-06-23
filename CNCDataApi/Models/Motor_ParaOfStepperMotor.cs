namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [Serializable]
    [DataContract]
    [Table(name: "Motor_ParaOfStepperMotor")]
    public partial class StepMotorPara
    {
        [Key]
        [StringLength(50)]
        public string TypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Manufacturer { get; set; }

        public double? TypeOfMotor { get; set; }

        public double? AngleOfStep { get; set; }

        public int? NumberOfPhase { get; set; }

        public int? Pace { get; set; }

        public double? PositionTorque { get; set; }

        public double? HoldingTorque { get; set; }

        [StringLength(25)]
        public string StepAngleAccuracy { get; set; }

        public double? InductanceCoefficient { get; set; }

        public double? RatedVoltage { get; set; }

        public double? RatedCurrency { get; set; }

        public double? WindingResistance { get; set; }

        public double? AllowableWorkingTemperature { get; set; }

        public int? NumberOfLeads { get; set; }

        public double? MomentOfInertia { get; set; }

        public double? Mass { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        [DataMember]
        public virtual StepMotorSize Motor_SizeOfStepperMotor { get; set; }
    }
}
