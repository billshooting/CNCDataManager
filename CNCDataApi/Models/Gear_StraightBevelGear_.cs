namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Gear_StraightBevelGear ")]
    public partial class Gear_StraightBevelGear_
    {
        [Key]
        [StringLength(50)]
        [Display(Name = "型号")]
        public string TypeNo { get; set; }

        [StringLength(50)]
        [Display(Name = "生产厂家")]
        public string Manufacturer { get; set; }

        [Display(Name = "模数m")]
        public double? Modulus_m { get; set; }

        [Display(Name = "压力角α")]
        public double? PressureAngle_α { get; set; }

        [Display(Name = "齿数z")]
        public int? NumberOfTeeth_z { get; set; }

        [Display(Name = "当量齿数zv")]
        public double? EquivalentNumberOfTeeth_zv { get; set; }

        [Display(Name = "节锥角δ")]
        public double? PitchAngle_δ { get; set; }

        [Display(Name = "顶锥角δa")]
        public double? TopBevelAngle_δa { get; set; }

        [Display(Name = "根锥角δf")]
        public double? RootBevelAngle_δf { get; set; }

        [Display(Name = "齿顶角θa")]
        public double? AddendumAngle_θa { get; set; }

        [Display(Name = "齿根角θf")]
        public double? DedendumAngle_θf { get; set; }

        [Display(Name = "齿顶高系数")]
        public double? AddendumCoefficient { get; set; }

        [Display(Name = "顶隙系数")]
        public double? HeadspaceCoefficient { get; set; }

        [Display(Name = "顶隙c")]
        public double? Headspace_c { get; set; }

        [Display(Name = "分度圆直径d")]
        public double? DiameterOfPitchCircle_d { get; set; }

        [Display(Name = "齿顶高ha")]
        public double? Addendum_ha { get; set; }

        [Display(Name = "齿根高hf")]
        public double? Dedendum_hf { get; set; }

        [Display(Name = "齿顶圆直径da")]
        public double? DiameterOfAddendumCircle_da { get; set; }

        [Display(Name = "齿根园直径df")]
        public double? DiameterOfDedendumCircle_df { get; set; }

        [Display(Name = "锥距R")]
        public double? ConeDistance_R { get; set; }

        [Display(Name = "分度圆齿厚s")]
        public double? ThicknessOfPicthCircleTeeth_s { get; set; }

        [Display(Name = "轮齿硬度")]
        public double? HardnessOfTeeth { get; set; }

        [StringLength(5)]
        [Display(Name = "齿轮精度等级")]
        public string GearAccuracyClass { get; set; }

        [StringLength(25)]
        [Display(Name = "材料")]
        public string Material { get; set; }

        [StringLength(25)]
        [Display(Name = "热处理方法")]
        public string HeatTreatment { get; set; }

        [Display(Name = "齿轮传动效率η")]
        public double? GearTransmissionEfficiency_η { get; set; }

        [Display(Name = "转动惯量")]
        public double? MomentOfInertia { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "说明")]
        public string Description { get; set; }
    }
}
