namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Motor_SizeOfServoMotorOfSpindle
    {
        [Key]
        [StringLength(50)]
        [Display(Name = "�ͺ�")]
        public string TypeNo { get; set; }

        [StringLength(50)]
        [Display(Name = "��������")]
        public string Manufacturer { get; set; }

        [Display(Name = "�ߴ�B")]
        public double? Size_B { get; set; }

        [Display(Name = "�ߴ�C")]
        public double? Size_C { get; set; }

        [Display(Name = "�ߴ�K")]
        public double? Size_K { get; set; }

        [Display(Name = "�ߴ�D")]
        public double? Size_D { get; set; }

        [Display(Name = "�ߴ�E1")]
        public double? Size_E1 { get; set; }

        [Display(Name = "�ߴ�E2")]
        public double? Size_E2 { get; set; }

        [Display(Name = "����ϵͳ�ŷ������������")]
        public virtual Motor_ParaOfServoMotorOfSpindle Motor_ParaOfServoMotorOfSpindle { get; set; }
    }
}
