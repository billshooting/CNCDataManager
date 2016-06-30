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
        [Display(Name = "型号")]
        public string TypeID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "生产厂家")]
        public string Manufacturer { get; set; }

        [Display(Name = "尺寸A")]
        public double? Size_A { get; set; }

        [Display(Name = "尺寸B")]
        public double? Size_B { get; set; }

        [Display(Name = "尺寸C")]
        public double? Size_C { get; set; }

        [Display(Name = "尺寸D")]
        public double? Size_D { get; set; }

        [Display(Name = "尺寸F")]
        public double? Size_F { get; set; }

        [Display(Name = "尺寸G")]
        public double? Size_G { get; set; }

        [JsonIgnore]
        [Display(Name = "步进电机技术参数")]
        public virtual StepMotorPara Motor_ParaOfStepperMotor { get; set; }
    }
}
