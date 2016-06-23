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
    [Table(name: "Motor_SizeOfServoMotorOfSpindle")]
    public partial class SpindleSrvMotorSize
    {
        [Key]
        [StringLength(50)]
        public string TypeID { get; set; }

        [StringLength(50)]
        public string Manufacturer { get; set; }

        public double? Size_B { get; set; }

        public double? Size_C { get; set; }

        public double? Size_K { get; set; }

        public double? Size_D { get; set; }

        public double? Size_E1 { get; set; }

        public double? Size_E2 { get; set; }

        [DataMember]
        public virtual SpindleSrvMotorPara Motor_ParaOfServoMotorOfSpindle { get; set; }
    }
}
