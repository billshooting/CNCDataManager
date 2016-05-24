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
        [Display(Name = "倰瘍")]
        public string TypeNo { get; set; }

        [StringLength(50)]
        [Display(Name = "汜莉釦模")]
        public string Manufacturer { get; set; }

        [Display(Name = "喜渡B")]
        public double? Size_B { get; set; }

        [Display(Name = "喜渡C")]
        public double? Size_C { get; set; }

        [Display(Name = "喜渡K")]
        public double? Size_K { get; set; }

        [StringLength(25)]
        [Display(Name = "喜渡F")]
        public string Size_F { get; set; }

        [Display(Name = "喜渡G")]
        public double? Size_G { get; set; }

        [StringLength(25)]
        [Display(Name = "喜渡D")]
        public string Size_D { get; set; }

        [Display(Name = "喜渡E1")]
        public double? Size_E1 { get; set; }

        [Display(Name = "喜渡E2")]
        public double? Size_E2 { get; set; }

        [Display(Name = "喜渡E3")]
        public double? Size_E3 { get; set; }
    }
}
