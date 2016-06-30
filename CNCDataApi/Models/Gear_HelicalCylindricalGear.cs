namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table(name: "Gear_HelicalCylindricalGear")]
    public partial class HeliCylinGear
    {
        [Key]
        [StringLength(10)]
        [Display(Name = "型号")]
        public string TypeID { get; set; }

        [StringLength(10)]
        [Display(Name = "生产厂家")]
        public string Manufacturer { get; set; }

        [Display(Name = "端面模数mt")]
        public double? ModulusOfEndSurface_mt { get; set; }

        [Display(Name = "法面模数mn")]
        public double? ModulusOfNormalSurface_mn { get; set; }

        [Display(Name = "压力角α")]
        public double? PressureAngle_α { get; set; }

        [Display(Name = "齿数z")]
        public int? NumberOfTeeth_z { get; set; }

        [Display(Name = "当量齿数zv")]
        public double? EquivalentNumberOfTeeth_zv { get; set; }

        [Display(Name = "螺旋角β")]
        public double? HelixAngle_β { get; set; }

        [Display(Name = "齿顶高系数")]
        public double? AddendumCoefficient { get; set; }

        [Display(Name = "顶隙系数")]
        public double? HeadspaceCoefficient { get; set; }

        [Display(Name = "变位系数χ")]
        public double? ModificationCoefficient_χ { get; set; }

        [Display(Name = "齿宽b")]
        public double? WidthOfTeeth_b { get; set; }

        [Display(Name = "分度圆直径d")]
        public double? DiameterOfPitchCircle_d { get; set; }

        [Display(Name = "基圆直径db")]
        public double? DiameterOfBaseCircle_db { get; set; }

        [Display(Name = "全齿高h")]
        public double? HeightOfFullTeeth_h { get; set; }

        [Display(Name = "齿顶高ha")]
        public double? Addendum_ha { get; set; }

        [Display(Name = "齿根高hf")]
        public double? Dedendum_hf { get; set; }

        [Display(Name = "端面吃菊pt")]
        public double? PitchOfEndSurfaceTeeth_pt { get; set; }

        [Display(Name = "法面齿距pn")]
        public double? PitchOfNormalSurfaceTeeth_pn { get; set; }

        [Display(Name = "端面齿厚st")]
        public double? ThicknessOfEndSurfaceTeeth_st { get; set; }

        [Display(Name = "齿顶圆直径da")]
        public double? DiameterOfAddendumCircle_da { get; set; }

        [Display(Name = "齿根圆直径df")]
        public double? DiameterOfDedendumCircle_df { get; set; }

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
