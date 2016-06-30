namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table(name: "Coupling_OldhamCoupling")]
    public partial class OldhamCoup
    {
        [Key]
        [StringLength(50)]
        [Display(Name = "型号")]
        public string TypeID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "生产厂家")]
        public string Manufacturer { get; set; }

        [Display(Name = "尺寸d1")]
        public double? Size_d1 { get; set; }

        [Display(Name = "公称转矩")]
        public double? NominalTorque { get; set; }

        [Display(Name = "许用转速")]
        public double? AllowableRotationSpeed { get; set; }

        [Display(Name = "尺寸D0")]
        public double? Size_D0 { get; set; }

        [Display(Name = "尺寸D")]
        public double? Size_D { get; set; }

        [Display(Name = "尺寸L")]
        public double? Size_L { get; set; }

        [Display(Name = "尺寸h")]
        public double? Size_h { get; set; }

        [Display(Name = "尺寸d2")]
        public double? Size_d2 { get; set; }

        [Display(Name = "尺寸c")]
        public double? Size_c { get; set; }

        [Display(Name = "质量")]
        public double? Mass { get; set; }

        [Display(Name = "转动惯量")]
        public double? MomentOfInertia { get; set; }

        [Display(Name = "刚度")]
        public double? Stiffness { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "说明")]
        public string Description { get; set; }
    }
}
