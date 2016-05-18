namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Coupling_GearCoupling
    {
        [Key]
        [StringLength(50)]
        [Display(Name = "型号")]
        public string TypeNo { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "生产厂家")]
        public string Manufacturer { get; set; }

        [Display(Name = "公称转矩")]
        public double? NominalTorque { get; set; }

        [Display(Name = "许用转速")]
        public double? AllowableRotationSpeed { get; set; }

        [Display(Name = "轴孔直径d1")]
        public double? DiameterOfShaftHole_d1 { get; set; }

        [Display(Name = "轴孔直径d2")]
        public double? DiameterOfShaftHole_d2 { get; set; }

        [Display(Name = "轴孔直径dz")]
        public double? DiameterOfShaftHole_dz { get; set; }

        [Display(Name = "Y型轴孔长度L")]
        public double? LengthOfYTypedShaftHole_L { get; set; }

        [Display(Name = "JJ1Z型轴孔长度L")]
        public double? LengthOfJJ1TypedShaftHoleL { get; set; }

        [Display(Name = "尺寸D")]
        public double? Size_D { get; set; }

        [Display(Name = "尺寸D1")]
        public double? Size_D1 { get; set; }

        [Display(Name = "尺寸D2")]
        public double? Size_D2 { get; set; }

        [Display(Name = "尺寸B")]
        public double? Size_B { get; set; }

        [Display(Name = "尺寸A")]
        public double? Size_A { get; set; }

        [Display(Name = "尺寸C")]
        public double? Size_C { get; set; }

        [Display(Name = "尺寸C1")]
        public double? Size_C1 { get; set; }

        [Display(Name = "尺寸C2")]
        public double? Size_C2 { get; set; }

        [Display(Name = "尺寸e")]
        public double? Size_e { get; set; }

        [Display(Name = "质量")]
        public double? Mass { get; set; }

        [Display(Name = "转动惯量")]
        public double? MomentOfInertia { get; set; }

        [Display(Name = "刚度")]
        public double? Stiffness { get; set; }

        [Display(Name = "说明")]
        [Column(TypeName = "text")]
        public string Description { get; set; }
    }
}
