namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Coupling_HubShapedCouplings
    {
        [Key]
        [StringLength(50)]
        [Display(Name = "型号")]
        public string TypeNo { get; set; }

        [StringLength(50)]
        [Display(Name = "生产厂家")]
        public string Manufacturer { get; set; }

        [Display(Name = "公称转矩")]
        public double? NominalTorque { get; set; }

        [Display(Name = "许用转速")]
        public double? AllowableRotationSpeed { get; set; }

        [StringLength(10)]
        [Display(Name = "轴孔直径d1")]
        public string DiameterOfShaftHole_d1 { get; set; }

        [StringLength(10)]
        [Display(Name = "轴孔直径d2")]
        public string DiameterOfShaftHole_d2 { get; set; }

        [Display(Name = "轴孔直径L1")]
        public double? DiameterOfShaftHole_L1 { get; set; }

        [Display(Name = "轴孔直径L2")]
        public double? DiameterOfShaftHole_L2 { get; set; }

        [Display(Name = "尺寸L0")]
        public double? Size_L0 { get; set; }

        [Display(Name = "尺寸D")]
        public double? Size_D { get; set; }

        [Display(Name = "尺寸D1")]
        public double? Size_D1 { get; set; }

        [Display(Name = "尺寸D2")]
        public double? Size_D2 { get; set; }

        [Display(Name = "尺寸E")]
        public double? Size_E { get; set; }

        [Display(Name = "尺寸S")]
        public double? Size_S { get; set; }

        [Display(Name = "转动惯量")]
        public double? MomentOfInertia { get; set; }

        [Display(Name = "重量")]
        public double? Weight { get; set; }

        [Display(Name = "刚度")]
        public double? Stiffness { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "说明")]
        public string Description { get; set; }
    }
}
