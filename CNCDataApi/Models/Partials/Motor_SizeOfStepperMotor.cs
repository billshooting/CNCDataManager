using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CNCDataApi.Models
{
    [MetadataType(typeof(StepMotorSizeMD))]
    public partial class StepMotorSize
    {
        public class StepMotorSizeMD
        {
            [Key]
            [StringLength(50)]
            [Column(name: "型号")]
            public string TypeID { get; set; }

            [Required]
            [StringLength(50)]
            [Column(name: "生产厂家")]
            public string Manufacturer { get; set; }

            [Column("尺寸A")]
            public double? Size_A { get; set; }

            [Column("尺寸B")]
            public double? Size_B { get; set; }

            [Column("尺寸C")]
            public double? Size_C { get; set; }

            [Column("尺寸D")]
            public double? Size_D { get; set; }

            [Column("尺寸F")]
            public double? Size_F { get; set; }

            [Column("尺寸G")]
            public double? Size_G { get; set; }

            [JsonIgnore]
            [IgnoreDataMember]
            public virtual StepMotorPara ParaOfStepMotor { get; set; }
        }
    }
}