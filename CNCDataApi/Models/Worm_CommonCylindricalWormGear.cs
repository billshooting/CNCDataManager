namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table(name: "Worm_CommonCylindricalWormGear")]
    public partial class CommonCylinWormGear
    {
        [Key]
        [StringLength(50)]
        [Display(Name = "型号")]
        public string TypeID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "生产厂家")]
        public string Manufacturer { get; set; }

        [Display(Name = "模数m")]
        public double? Modulus_m { get; set; }

        [Display(Name = "齿形角α")]
        public double? ProfileAngle_α { get; set; }

        [Display(Name = "中心距a")]
        public double? CentralDistance_a { get; set; }

        [Display(Name = "蜗杆齿数z1")]
        public int? NumberOfWormTeeth_z1 { get; set; }

        [Display(Name = "涡轮齿数z2")]
        public int? NumberOfWormGearWheelTeeth_z2 { get; set; }

        [Display(Name = "传动比i")]
        public double? DriveRatio_i { get; set; }

        [Display(Name = "变位系数χ2")]
        public double? ModificationCoefficient_χ2 { get; set; }

        [Display(Name = "蜗杆分度圆直径d1")]
        public double? DiameterOfPitchCircleOfWorm_d1 { get; set; }

        [Display(Name = "蜗杆轴向齿距px")]
        public double? AxialPitchOfWorm_px { get; set; }

        [Display(Name = "蜗杆导程")]
        public double? LeadOfWorm_pz { get; set; }

        [Display(Name = "蜗轮分度圆柱导程角γ")]
        public double? LeadAngleOfPitchCircleOfWormWheel_γ { get; set; }

        [Display(Name = "顶隙c")]
        public double? HeadSpace_c { get; set; }

        [Display(Name = "蜗杆齿顶高ha1")]
        public double? WormAddendum_ha1 { get; set; }

        [Display(Name = "蜗杆齿根高hf1")]
        public double? WormDedendum_hf1 { get; set; }

        [Display(Name = "蜗杆全齿高h1")]
        public double? TeethHeightOfWorm_h1 { get; set; }

        [Display(Name = "蜗杆齿顶圆直径da1")]
        public double? DiameterOfAddendumCircleOfWorm_da1 { get; set; }

        [Display(Name = "蜗杆齿根圆直径df1")]
        public double? DiameterOfDedendumCircleOfWorm_df1 { get; set; }

        [Display(Name = "蜗杆螺纹部分长度b1")]
        public double? LengthOfScrewThreadOfWorm_b1 { get; set; }

        [Display(Name = "蜗杆轴向齿厚Sx1")]
        public double? AxialThicknessOfWorm_Sx1 { get; set; }

        [Display(Name = "蜗杆轴向齿厚Sn1")]
        public double? NormalThicknessOfWorm_Sn1 { get; set; }

        [Display(Name = "蜗轮喉圆直径d2")]
        public double? DiameterOfThroatCircleOfWormWheel_d2 { get; set; }

        [Display(Name = "蜗轮齿顶高ha2")]
        public double? AddendumOfWormWheel_ha2 { get; set; }

        [Display(Name = "蜗轮齿根高hf2")]
        public double? DedendumOfWormWheel_hf2 { get; set; }

        [Display(Name = "蜗轮喉圆直径da2")]
        public double? DiameterOfThroatCircleOfWormWheel_da2 { get; set; }

        [Display(Name = "蜗轮齿宽b2")]
        public double? TeethWidthOfWormWheel_b2 { get; set; }

        [Display(Name = "蜗轮齿根圆弧半径R1")]
        public double? RadiusOfRootTeethOfWormWheel_R1 { get; set; }

        [Display(Name = "蜗轮齿根圆弧半径R2")]
        public double? RadiusOfRootTeethOfWormWheel_R2 { get; set; }

        [Display(Name = "涡轮齿顶圆直径de2")]
        public double? DiameterOfAddendumCircleOfWormWheel_de2 { get; set; }

        [Display(Name = "蜗轮轮缘宽度B")]
        public double? FlangeWidthOfWormWheel_B { get; set; }

        [Display(Name = "齿廓圆弧中心到蜗杆齿厚对称线距离")]
        public double? Length_l1 { get; set; }

        [Display(Name = "齿廓圆弧中心到蜗杆齿厚轴线的距离")]
        public double? Length_l2 { get; set; }

        [Display(Name = "传动效率η")]
        public double? TransmissionEfficiency_η { get; set; }

        //[Column("ViscousFrictionOfWormShaft           ")]
        //[Display(Name = "蜗杆轴粘滞摩擦")]
        public double? ViscousFrictionOfWormShaft { get; set; }

        [Display(Name = "蜗轮转动惯量")]
        public double? MomentOfInertiaOfWormWheel { get; set; }

        [Display(Name = "蜗杆转动惯量")]
        public double? MomentOfInertiaOFWorm { get; set; }

        [Display(Name = "蜗杆轴的扭转刚度")]
        public double? TorsionalStiffnessOfWormShaft { get; set; }

        [StringLength(25)]
        [Display(Name = "材料")]
        public string Material { get; set; }

        [StringLength(25)]
        [Display(Name = "铸造过程")]
        public string CastingProcess { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "说明")]
        public string Description { get; set; }
    }
}
