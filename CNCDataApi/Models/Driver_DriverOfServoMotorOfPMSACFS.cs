namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Driver_DriverOfServoMotorOfPMSACFS
    {
        [Key]
        [StringLength(50)]
        [Display(Name = "型号")]
        public string TypeNo { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "生产厂家")]
        public string Manufacturer { get; set; }

        [Display(Name = "连续电流")]
        public double? ContinuousCurrent { get; set; }

        [Display(Name = "峰值电流")]
        public double? PeakCurrent { get; set; }

        [StringLength(50)]
        [Display(Name = "电源电压")]
        public string SupplyVoltage { get; set; }

        [Display(Name = "最大适配电机功率")]
        public double? MaxAdaptableMotorPower { get; set; }

        [Display(Name = "最大制动电流")]
        public double? MaxBrakingCurrent { get; set; }

        [StringLength(50)]
        [Display(Name = "外接制动电阻")]
        public string ExternalBrakingResistance { get; set; }

        [Display(Name = "PWM周期")]
        public double? CycleOfPWM { get; set; }

        [Display(Name = "直流供电电压")]
        public double? SupplyVoltageOfDC { get; set; }

        [Display(Name = "位置环增益")]
        public double? PositionLoopGain { get; set; }

        [Display(Name = "速度环增益")]
        public double? SpeedLoopGain { get; set; }

        [Display(Name = "速度环积分常数")]
        public double? IntegralConstantOfSpeedLoop { get; set; }

        [Display(Name = "d轴电流增益值")]
        public double? GainOfDaxisCurrent { get; set; }

        [Display(Name = "d轴电流积分常数")]
        public double? IntegralConstantOfDaxisCurrent { get; set; }

        [Display(Name = "说明")]
        [Column(TypeName = "text")]
        public string Description { get; set; }
    }
}
