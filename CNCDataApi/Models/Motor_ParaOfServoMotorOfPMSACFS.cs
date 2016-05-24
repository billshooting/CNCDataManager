namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Motor_ParaOfServoMotorOfPMSACFS
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

        [Display(Name = "最大转矩")]
        public double? MaxTorque { get; set; }

        [Display(Name = "额定转速")]
        public int? RatedRotationSpeed { get; set; }

        [Display(Name = "最大转速")]
        public int? MaxRotationSpeed { get; set; }

        [Display(Name = "转动惯量")]
        public double? MomentOfInertia { get; set; }

        [Display(Name = "额定功率")]
        public double? RatedPower { get; set; }

        [Display(Name = "静力矩")]
        public double? StaticTorque { get; set; }

        [Display(Name = "电机磁极对数")]
        public int? PairsOfMotorPole { get; set; }

        [Display(Name = "直流母线电压")]
        public double? DCLinkVoltage { get; set; }

        [Display(Name = "额定电流")]
        public double? RatedCurrent { get; set; }

        [Display(Name = "最大电流")]
        public double? MaxCurrent { get; set; }

        [Display(Name = "机械事件常数")]
        public double? MechanicalTimeConstant { get; set; }

        [Display(Name = "质量")]
        public double? Mass { get; set; }

        [Display(Name = "静子电阻")]
        public double? StatorResistance { get; set; }

        [Display(Name = "每相静子绕组漏感")]
        public double? LeakageInductanceOfEachPhaseOfStatorWinding { get; set; }

        [Display(Name = "反电动势")]
        public double? CounterElectromotiveForce { get; set; }

        [Display(Name = "额定频率")]
        public int? RatedFrequency { get; set; }

        [Display(Name = "电机转子转动惯量")]
        public double? MomentOfInertiaOfMotorRotor { get; set; }

        [Display(Name = "每相绕组电阻")]
        public double? ResistanceOfPhaseWinding { get; set; }

        [Display(Name = "每相绕组电感")]
        public double? InductanceOfPhaseWinding { get; set; }

        [StringLength(10)]
        [Display(Name = "是否带抱闸")]
        public string IfWithBrake { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "说明")]
        public string Description { get; set; }
    }
}
