namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table(name: "Coupling_BrakeWheelElasticSleevePinCoupling")]
    public partial class BWElasticSlvPinCoup
    {
        [Key]
        [StringLength(50)]
        [Display(Name = "型号")]
        public string TypeID { get; set; }

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
        public double? LengthOfJJ1ZTypedShaftHole_L { get; set; }

        [Display(Name = "JJ1Z型轴孔长度L1")]
        public double? LengthOfJJ1ZTypedShaftHole_L1 { get; set; }

        [Display(Name = "推荐轴孔长度L")]
        public double? RecommendedLengthOfShaftHole_L { get; set; }

        [Display(Name = "尺寸D0")]
        public double? Size_D0 { get; set; }

        [Display(Name = "尺寸D")]
        public double? Size_D { get; set; }

        [Display(Name = "尺寸B")]
        public double? Size_B { get; set; }

        [Display(Name = "尺寸A")]
        public double? Size_A { get; set; }

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
