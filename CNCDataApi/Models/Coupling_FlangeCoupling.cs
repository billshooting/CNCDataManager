namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Coupling_FlangeCoupling
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

        [Display(Name = "许用转速_钢")]
        public double? AllowableRotationSpeed_Steel { get; set; }

        [Display(Name = "许用转速_铁")]
        public double? AllowableRotationSpeed_Iron { get; set; }

        [Display(Name = "轴孔直径d")]
        public double? DiameterOfShaftHole_d { get; set; }

        [Display(Name = "Y型轴孔长度L")]
        public double? LengthOfYTypedShaftHole_L { get; set; }

        [Display(Name = "JJ1Y型轴孔长度L")]
        public double? LengthOfJJ1TypedShaftHole_L { get; set; }

        [Display(Name = "尺寸D")]
        public double? Size_D { get; set; }

        [Display(Name = "尺寸D1")]
        public double? Size_D1 { get; set; }

        [Display(Name = "螺栓数量")]
        public int? NumberOfBolts { get; set; }

        [StringLength(10)]
        [Display(Name = "螺栓直径")]
        public string DiameterOfBolts { get; set; }

        [Display(Name = "Y型尺寸L0")]
        public double? SizeOfYTyped_L0 { get; set; }

        [Display(Name = "JJ1型尺寸L0")]
        public double? SizeOfJJ1Typed_L0 { get; set; }

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
