namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Motor_ParaOfElectricSpindle
    {
        [Key]
        [StringLength(50)]
        [Display(Name = "型号")]
        public string TypeNo { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "生产厂家")]
        public string Manufacturer { get; set; }

        [Display(Name = "额定转矩")]
        public double? RatedTorque { get; set; }

        [Display(Name = "额定转速")]
        public int? RatedRotationSpeed { get; set; }

        [Display(Name = "最大转速")]
        public int? MaxRotationSpeed { get; set; }

        [Display(Name = "转动惯量")]
        public double? MomentOfInertia { get; set; }

        [Display(Name = "额定功率")]
        public double? RatedPower { get; set; }

        [Display(Name = "额定电流")]
        public double? RatedCurrent { get; set; }

        [Display(Name = "最大电流")]
        public double? MaxCurrent { get; set; }

        [Display(Name = "直流母线电压")]
        public double? DCLinkVoltage { get; set; }

        [Display(Name = "反电动势系数")]
        public double? BackEMFCoefficient { get; set; }

        [Display(Name = "热时间常数")]
        public double? ThermalTimeConstant { get; set; }

        [Display(Name = "转子质量")]
        public double? MassOfRotor { get; set; }

        [Display(Name = "定子质量")]
        public double? MassOfStator { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "说明")]
        public string Description { get; set; }

        [Display(Name = "电主轴尺寸数据")]
        public virtual Motor_SizeOfElectricSpindle Motor_SizeOfElectricSpindle { get; set; }
    }
}
