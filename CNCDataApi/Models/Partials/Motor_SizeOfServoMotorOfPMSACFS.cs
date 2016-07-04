﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CNCDataApi.Models
{
    [MetadataType(typeof(PMSrvMotorSizeMD))]
    public partial class PMSrvMotorSize
    {
        public class PMSrvMotorSizeMD
        {
            [Key]
            [StringLength(50)]
            [Column(name: "型号")]
            public string TypeID { get; set; }

            [Required]
            [StringLength(50)]
            [Column(name: "生产厂家")]
            public string Manufacturer { get; set; }

            [Column("尺寸B(mm)")]
            public double? Size_B { get; set; }

            [Column("尺寸C(mm)")]
            public double? Size_C { get; set; }

            [Column("尺寸K(mm)")]
            public double? Size_K { get; set; }

            [Column("尺寸F(mm)")]
            [StringLength(25)]
            public string Size_F { get; set; }

            [Column("尺寸G(mm)")]
            public double? Size_G { get; set; }

            [Column("尺寸D(mm)")]
            [StringLength(25)]
            public string Size_D { get; set; }

            [Column("尺寸E1(mm)")]
            public double? Size_E1 { get; set; }

            [Column("尺寸E2(mm)")]
            public double? Size_E2 { get; set; }

            [Column("尺寸E3(mm)")]
            public double? Size_E3 { get; set; }

            [JsonIgnore]
            [IgnoreDataMember]
            public virtual PMSrvMotorPara ParaOfPMSrvMotor { get; set; }
        }
    }
}