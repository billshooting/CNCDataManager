namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table(name: "NutPairs_SolidBallScrewNutPairs")]
    public partial class SolidBallScrewNutPairs
    {
        [Key]
        [StringLength(50)]
        [Display(Name = "型号")]
        public string TypeID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "生产厂家")]
        public string Manufacturer { get; set; }

        [Display(Name = "基本额定动载荷Ca")]
        public double? BasicRatedDynamicLoad_Ca { get; set; }

        [Display(Name = "基本额定静载荷Coa")]
        public double? BasicRatedStaticLoad_Coa { get; set; }

        [Display(Name = "刚度")]
        public double? Stiffness { get; set; }

        [Display(Name = "公称直径d0")]
        public double? NominalDiameter_d0 { get; set; }

        [Display(Name = "公称导程ph0")]
        public double? NominalLead_Ph0 { get; set; }

        [Display(Name = "丝杠外径d1")]
        public double? OuterDiameterOfScrew_d1 { get; set; }

        [Display(Name = "钢球直径DW")]
        public double? DiameterOfSteelBall_DW { get; set; }

        [Display(Name = "丝杠底径d2")]
        public double? BottomDiameterOfScrew_d2 { get; set; }

        [Display(Name = "轴承配合直径")]
        public double? AdaptableDiameterWithBearing { get; set; }

        [Display(Name = "轴承轴孔配合直径")]
        public double? AdaptableDiameterWithCouplingShaftHole { get; set; }

        [Display(Name = "极限转速")]
        public int? LimitRotationSpeed { get; set; }

        [Display(Name = "两双推轴承之间的距离")]
        public double? DistanceBetweenTwoPushBearings { get; set; }

        [Display(Name = "丝杠长度L")]
        public double? LengthOfScrew_L { get; set; }

        [Display(Name = "循环总圈数n")]
        public int? TotalCycleTurns_n { get; set; }

        [Display(Name = "尺寸D3")]
        public double? Size_D3 { get; set; }

        [Display(Name = "尺寸D4")]
        public double? Size_D4 { get; set; }

        [Display(Name = "尺寸D5")]
        public double? Size_D5 { get; set; }

        [Display(Name = "尺寸D6")]
        public double? Size_D6 { get; set; }

        [Display(Name = "尺寸D7")]
        public double? Size_D7 { get; set; }

        [Display(Name = "尺寸L1")]
        public double? Size_L1 { get; set; }

        [Display(Name = "螺栓孔数目m")]
        public int? NumberOfScrewHoles_m { get; set; }

        [Display(Name = "密度")]
        public double? Density { get; set; }

        [Display(Name = "弹性模量")]
        public double? ElasticModulus { get; set; }

        [Display(Name = "剪切弹性模量")]
        public double? ShearElasticModulus { get; set; }

        [Display(Name = "丝杠与螺母结合面径向阻尼系数")]
        public double? RadialDampingCoefficient { get; set; }

        [Display(Name = "滚珠丝杠副处的粘滞摩擦因素")]
        public double? ViscousFrictionFactor { get; set; }

        [Display(Name = "滚珠丝杠预紧效率")]
        public double? EfficiencyOfBallScrewPreload { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "说明")]
        public string Description { get; set; }
    }
}
