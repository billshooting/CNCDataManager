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
    [Table(name: "Motor_SizeOfStepperMotor")]
    public partial class StepMotorSize
    {
        [Key]
        [StringLength(50)]
        public string TypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Manufacturer { get; set; }

        public double? Size_A { get; set; }

        public double? Size_B { get; set; }

        public double? Size_C { get; set; }

        public double? Size_D { get; set; }

        public double? Size_F { get; set; }

        public double? Size_G { get; set; }

        [DataMember]
        public virtual StepMotorPara Motor_ParaOfStepperMotor { get; set; }
    }
}
