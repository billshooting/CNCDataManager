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
    [Table(name: "Motor_SizeOfElectricSpindle")]
    public partial class ElecSpindleSize
    {
        [Key]
        [StringLength(50)]
        public string TypeID { get; set; }

        [StringLength(50)]
        public string Manufacturer { get; set; }

        public double? Size_C { get; set; }

        public double? Size_D1 { get; set; }

        public double? Size_D2 { get; set; }

        public double? Size_J { get; set; }

        public double? Size_K { get; set; }

        public double? Size_L { get; set; }

        public double? Size_M { get; set; }

        public double? Size_N { get; set; }

        [DataMember]
        public virtual ElecSpindlePara Motor_ParaOfElectricSpindle { get; set; }
    }
}
