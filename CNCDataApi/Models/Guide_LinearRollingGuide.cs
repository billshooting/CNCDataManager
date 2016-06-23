namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table(name: "Guide_LinearRollingGuide")]
    public partial class LinearRollGuide
    {
        [Key]
        [StringLength(50)]
        public string TypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Manufacturer { get; set; }

        [StringLength(10)]
        public string SizeOfGuideFixedBolt { get; set; }

        [StringLength(10)]
        public string RollerType { get; set; }

        public double? BasicRatedDynamicLoad_C { get; set; }

        public double? BasicRatedStaticLoad_C0 { get; set; }

        public double? AllowableStaticMoment_MR { get; set; }

        public double? AllowableStaticMoment_Mp { get; set; }

        public double? AllowableStaticMoment_Mq { get; set; }

        public double? MassOfSlider { get; set; }

        public double? MassOfGuide { get; set; }

        public double? SizeOfComponent_H { get; set; }

        public double? SizeOfComponent_H1 { get; set; }

        public double? SizeOfComponent_N { get; set; }

        public double? SizeOfSlider_W { get; set; }

        public double? SizeOfSlider_B { get; set; }

        public double? SizeOfSlider_B1 { get; set; }

        public double? SizeOfSlider_C { get; set; }

        public double? SizeOfSlider_L1 { get; set; }

        public double? SizeOfSlider_L { get; set; }

        [StringLength(10)]
        public string SizeOfSlider_K { get; set; }

        public double? SizeOfSlider_G { get; set; }

        [StringLength(10)]
        public string SizeOfSlider_M { get; set; }

        public double? SizeOfSlider_T { get; set; }

        public double? SizeOfSlider_T1 { get; set; }

        [StringLength(10)]
        public string SizeOfSlider_T2 { get; set; }

        public double? SizeOfSlider_H2 { get; set; }

        public double? SizeOfSlider_H3 { get; set; }

        public double? SizeOfGuide_WR { get; set; }

        public double? SizeOfGuide_HR { get; set; }

        public double? SizeOfGuide_D { get; set; }

        public double? SizeOfGuide_h { get; set; }

        public double? SizeOfGuide_d1 { get; set; }

        public double? SizeOfGuide_P { get; set; }

        public double? SizeOfGuide_E { get; set; }

        public double? CoefficientOfFrictionGuidPairs { get; set; }

        public double? CoefficientOfViscousFriction { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }
    }
}
