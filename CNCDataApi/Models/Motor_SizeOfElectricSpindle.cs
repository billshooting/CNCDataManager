namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Motor_SizeOfElectricSpindle
    {
        [Key]
        [StringLength(50)]
        [Display(Name = "型号")]
        public string TypeNo { get; set; }

        [StringLength(50)]
        [Display(Name = "生产厂家")]
        public string Manufacturer { get; set; }

        [Display(Name = "尺寸C")]
        public double? Size_C { get; set; }

        [Display(Name = "尺寸D1")]
        public double? Size_D1 { get; set; }

        [Display(Name = "尺寸D2")]
        public double? Size_D2 { get; set; }

        [Display(Name = "尺寸J")]
        public double? Size_J { get; set; }

        [Display(Name = "尺寸K")]
        public double? Size_K { get; set; }

        [Display(Name = "尺寸L")]
        public double? Size_L { get; set; }

        [Display(Name = "尺寸M")]
        public double? Size_M { get; set; }

        [Display(Name = "尺寸N")]
        public double? Size_N { get; set; }

        [Display(Name = "电主轴技术参数")]
        public virtual Motor_ParaOfElectricSpindle Motor_ParaOfElectricSpindle { get; set; }
    }
}
