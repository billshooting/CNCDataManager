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
    [Table(name: "Motor_ParaOfServoMotorOfSpindle")]
    public partial class SpindleSrvMotorPara
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

        public double? RatedCurrent { get; set; }

        public double? MaxCurrent { get; set; }

        public double? Weight { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        [DataMember]
        public virtual SpindleSrvMotorSize Motor_SizeOfServoMotorOfSpindle { get; set; }
    }
}
