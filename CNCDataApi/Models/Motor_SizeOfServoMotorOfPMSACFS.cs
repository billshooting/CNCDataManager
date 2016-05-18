namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Motor_SizeOfServoMotorOfPMSACFS
    {
        [Key]
        [StringLength(50)]
        [Display(Name = "型号")]
        public string TypeNo { get; set; }

        [StringLength(50)]
        [Display(Name = "生产厂家")]
        public string Manufacturer { get; set; }

        [Display(Name = "尺寸B")]
        public double? Size_B { get; set; }

        [Display(Name = "尺寸C")]
        public double? Size_C { get; set; }

        [Display(Name = "尺寸K")]
        public double? Size_K { get; set; }

        [StringLength(25)]
        [Display(Name = "尺寸F")]
        public string Size_F { get; set; }

        [Display(Name = "尺寸G")]
        public double? Size_G { get; set; }

        [StringLength(25)]
        [Display(Name = "尺寸D")]
        public string Size_D { get; set; }

        [Display(Name = "尺寸E1")]
        public double? Size_E1 { get; set; }

        [Display(Name = "尺寸E2")]
        public double? Size_E2 { get; set; }

        [Display(Name = "尺寸E3")]
        public double? Size_E3 { get; set; }

        [Display(Name = "永磁同步交流进给系统伺服电机技术参数")]
        public virtual Motor_ParaOfServoMotorOfPMSACFS Motor_ParaOfServoMotorOfPMSACFS { get; set; }
    }
}
