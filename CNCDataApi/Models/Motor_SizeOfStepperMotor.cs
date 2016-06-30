namespace CNCDataApi.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table(name: "Motor_SizeOfStepperMotor")]
    public partial class StepMotorSize
    {
        [Key]
        [StringLength(50)]
        [Display(Name = "�ͺ�")]
        public string TypeID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "��������")]
        public string Manufacturer { get; set; }

        [Display(Name = "�ߴ�A")]
        public double? Size_A { get; set; }

        [Display(Name = "�ߴ�B")]
        public double? Size_B { get; set; }

        [Display(Name = "�ߴ�C")]
        public double? Size_C { get; set; }

        [Display(Name = "�ߴ�D")]
        public double? Size_D { get; set; }

        [Display(Name = "�ߴ�F")]
        public double? Size_F { get; set; }

        [Display(Name = "�ߴ�G")]
        public double? Size_G { get; set; }

        [JsonIgnore]
        [Display(Name = "���������������")]
        public virtual StepMotorPara Motor_ParaOfStepperMotor { get; set; }
    }
}
