namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bearings_BallLeadScrewSupportBearings
    {
        [Key]
        [StringLength(50)]
        [Display(Name = "型号")]
        public string TypeNo { get; set; }

        [StringLength(50)]
        [Display(Name = "生产厂家")]
        public string Manufacturer { get; set; }

        [Display(Name = "接触角Alpha")]
        public double? ContactAngle_Alpha { get; set; }

        [Display(Name = "基本额定动载荷")]
        public double? BasicRatedDynamicLoad { get; set; }

        [Display(Name = "轴向极限载荷")]
        public double? AxialLoadLimit { get; set; }

        [Display(Name = "脂润滑极限速度")]
        public double? SpeedLimitOfGrease { get; set; }

        [Display(Name = "油润滑极限速度")]
        public double? SpeedLimitOfOil { get; set; }

        [Display(Name = "内径d")]
        public double? InnerDiameter_d { get; set; }

        [Display(Name = "直径D")]
        public double? Diameter_D { get; set; }

        [Display(Name = "宽度B")]
        public double? Width_B { get; set; }

        [Display(Name = "尺寸r")]
        public double? Size_r { get; set; }

        [Display(Name = "尺寸r1")]
        public double? Size_r1 { get; set; }

        [Display(Name = "尺寸da1")]
        public double? Size_da1 { get; set; }

        [Display(Name = "尺寸da2")]
        public double? Size_da2 { get; set; }

        [Display(Name = "尺寸Dda1")]
        public double? Size_Dda1 { get; set; }

        [Display(Name = "尺寸Dda2")]
        public double? Size_Dda2 { get; set; }

        [Display(Name = "质量")]
        public double? Mass { get; set; }

        [Display(Name = "轴承轴向刚度")]
        public double? BearingAxialStiffness { get; set; }

        [Display(Name = "轴承启动转矩")]
        public double? BearingStartingTorque { get; set; }

        [Display(Name = "说明")]
        [Column(TypeName = "text")]
        public string Description { get; set; }
    }
}
