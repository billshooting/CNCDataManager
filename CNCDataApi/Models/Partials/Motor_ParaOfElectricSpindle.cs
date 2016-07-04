using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CNCDataApi.Models
{
    //为解决循环引用而设
    [MetadataType(typeof(ElecSpindleParaMD))]
    public partial class ElecSpindlePara
    {
        public class ElecSpindleParaMD
        {
            [Key]
            [StringLength(50)]
            [Column(name: "型号")]
            public string TypeID { get; set; }

            [Required]
            [StringLength(50)]
            [Column(name: "生产厂家")]
            public string Manufacturer { get; set; }

            [Column(name: "额定转矩")]
            public double? RatedTorque { get; set; }

            [Column(name: "额定转速")]
            public int? RatedRotationSpeed { get; set; }

            [Column(name: "最大转速")]
            public int? MaxRotationSpeed { get; set; }

            [Column(name: "转动惯量")]
            public double? MomentOfInertia { get; set; }

            [Column(name: "额定功率")]
            public double? RatedPower { get; set; }

            [Column(name: "额定电流")]
            public double? RatedCurrent { get; set; }

            [Column(name: "最大电流")]
            public double? MaxCurrent { get; set; }

            [Column(name: "直流母线电压")]
            public double? DCLinkVoltage { get; set; }

            [Column(name: "反电动势系数")]
            public double? BackEMFCoefficient { get; set; }

            [Column(name: "热时间常数")]
            public double? ThermalTimeConstant { get; set; }

            [Column(name: "转子质量")]
            public double? MassOfRotor { get; set; }

            [Column(name: "定子质量")]
            public double? MassOfStator { get; set; }

            [Column(name: "说明", TypeName = "text")]
            public string Description { get; set; }

            [JsonIgnore]
            [IgnoreDataMember]
            public virtual ElecSpindleSize SizeOfElecSpindle { get; set; }
        }
    }
}