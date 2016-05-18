namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Guide_LinearRollingGuide
    {
        [Key]
        [StringLength(50)]
        [Display(Name = "型号")]
        public string TypeNo { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "生产厂家")]
        public string Manufacturer { get; set; }

        [StringLength(10)]
        [Display(Name = "导轨固定螺栓大小")]
        public string SizeOfGuideFixedBolt { get; set; }

        [StringLength(10)]
        [Display(Name = "滚子类型")]
        public string RollerType { get; set; }

        [Display(Name = "基本额定动载荷C")]
        public double? BasicRatedDynamicLoad_C { get; set; }

        [Display(Name = "基本额定静载荷C0")]
        public double? BasicRatedStaticLoad_C0 { get; set; }

        [Display(Name = "容许静力矩MR")]
        public double? AllowableStaticMoment_MR { get; set; }

        [Display(Name = "容许静力矩Mp")]
        public double? AllowableStaticMoment_Mp { get; set; }

        [Display(Name = "容许静力矩Mq")]
        public double? AllowableStaticMoment_Mq { get; set; }

        [Display(Name = "滑块质量")]
        public double? MassOfSlider { get; set; }

        [Display(Name = "导轨质量")]
        public double? MassOfGuide { get; set; }

        [Display(Name = "组件大小H")]
        public double? SizeOfComponent_H { get; set; }

        [Display(Name = "组件大小H1")]
        public double? SizeOfComponent_H1 { get; set; }

        [Display(Name = "组件大小N")]
        public double? SizeOfComponent_N { get; set; }

        [Display(Name = "滑块大小W")]
        public double? SizeOfSlider_W { get; set; }

        [Display(Name = "滑块大小B")]
        public double? SizeOfSlider_B { get; set; }

        [Display(Name = "滑块大小B1")]
        public double? SizeOfSlider_B1 { get; set; }

        [Display(Name = "滑块大小C")]
        public double? SizeOfSlider_C { get; set; }

        [Display(Name = "滑块大小L1")]
        public double? SizeOfSlider_L1 { get; set; }

        [Display(Name = "滑块大小L")]
        public double? SizeOfSlider_L { get; set; }

        [StringLength(10)]
        [Display(Name = "滑块大小K")]
        public string SizeOfSlider_K { get; set; }

        [Display(Name = "滑块大小G")]
        public double? SizeOfSlider_G { get; set; }

        [StringLength(10)]
        [Display(Name = "滑块大小M")]
        public string SizeOfSlider_M { get; set; }

        [Display(Name = "滑块大小T")]
        public double? SizeOfSlider_T { get; set; }

        [Display(Name = "滑块大小T1")]
        public double? SizeOfSlider_T1 { get; set; }

        [StringLength(10)]
        [Display(Name = "滑块大小T2")]
        public string SizeOfSlider_T2 { get; set; }

        [Display(Name = "滑块大小H2")]
        public double? SizeOfSlider_H2 { get; set; }

        [Display(Name = "滑块大小H3")]
        public double? SizeOfSlider_H3 { get; set; }

        [Display(Name = "导轨大小WR")]
        public double? SizeOfGuide_WR { get; set; }

        [Display(Name = "导轨大小HR")]
        public double? SizeOfGuide_HR { get; set; }

        [Display(Name = "导轨大小D")]
        public double? SizeOfGuide_D { get; set; }

        [Display(Name = "导轨大小h")]
        public double? SizeOfGuide_h { get; set; }

        [Display(Name = "导轨大小d1")]
        public double? SizeOfGuide_d1 { get; set; }

        [Display(Name = "导轨大小P")]
        public double? SizeOfGuide_P { get; set; }

        [Display(Name = "导轨大小E")]
        public double? SizeOfGuide_E { get; set; }

        [Display(Name = "导轨副的摩擦系数")]
        public double? CoefficientOfFrictionGuidPairs { get; set; }

        [Display(Name = "粘滞摩擦因子")]
        public double? CoefficientOfViscousFriction { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "说明")]
        public string Description { get; set; }
    }
}
