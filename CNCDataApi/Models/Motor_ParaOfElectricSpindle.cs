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
    [Table(name: "Motor_ParaOfElectricSpindle")]
    public partial class ElecSpindlePara
    {
        [Key]
        [StringLength(50)]
        public string TypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Manufacturer { get; set; }

        public double? RatedTorque { get; set; }

        public int? RatedRotationSpeed { get; set; }

        public int? MaxRotationSpeed { get; set; }

        public double? MomentOfInertia { get; set; }

        public double? RatedPower { get; set; }

        public double? RatedCurrent { get; set; }

        public double? MaxCurrent { get; set; }

        public double? DCLinkVoltage { get; set; }

        public double? BackEMFCoefficient { get; set; }

        public double? ThermalTimeConstant { get; set; }

        public double? MassOfRotor { get; set; }

        public double? MassOfStator { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        [DataMember]
        public virtual ElecSpindleSize Motor_SizeOfElectricSpindle { get; set; }
    }
}
