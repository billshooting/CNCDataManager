namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Motor_ParaOfStepperMotor
    {
        [Key]
        [StringLength(50)]
        [Display(Name = "型号")]
        public string TypeNo { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "生产厂家")]
        public string Manufacturer { get; set; }

        [Display(Name = "电机类型")]
        public double? TypeOfMotor { get; set; }

        [Display(Name = "步距角")]
        public double? AngleOfStep { get; set; }

        [Display(Name = "相数")]
        public int? NumberOfPhase { get; set; }

        [Display(Name = "拍数")]
        public int? Pace { get; set; }

        [Display(Name = "定位转矩")]
        public double? PositionTorque { get; set; }

        [Display(Name = "保持转矩")]
        public double? HoldingTorque { get; set; }

        [StringLength(25)]
        [Display(Name = "步距角精度")]
        public string StepAngleAccuracy { get; set; }

        [Display(Name = "电感系数")]
        public double? InductanceCoefficient { get; set; }

        [Display(Name = "额定电压")]
        public double? RatedVoltage { get; set; }

        [Display(Name = "额定电流")]
        public double? RatedCurrency { get; set; }

        [Display(Name = "绕组电阻")]
        public double? WindingResistance { get; set; }

        [Display(Name = "允许工作温度")]
        public double? AllowableWorkingTemperature { get; set; }

        [Display(Name = "引线数")]
        public int? NumberOfLeads { get; set; }

        [Display(Name = "转动惯量")]
        public double? MomentOfInertia { get; set; }

        [Display(Name = "质量")]
        public double? Mass { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "说明")]
        public string Description { get; set; }

        [Display(Name = "步进电机尺寸")]
        public virtual Motor_SizeOfStepperMotor Motor_SizeOfStepperMotor { get; set; }
    }
}
