namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bearings_NeedleRollerAndThrustRollerBearings
    {
        [Key]
        [StringLength(50)]
        [Display(Name = "型号")]
        public string TypeNo { get; set; }

        [StringLength(50)]
        [Display(Name = "生产厂家")]
        public string Manufacturer { get; set; }

        [Display(Name = "内径d")]
        public double? InnerDiameter_d { get; set; }

        [Display(Name = "直径D")]
        public double? Diameter_D { get; set; }

        [Display(Name = "宽度T")]
        public double? Width_T { get; set; }

        [Display(Name = "尺寸T1")]
        public double? Size_T1 { get; set; }

        [Display(Name = "尺寸C")]
        public double? Size_C { get; set; }

        [Display(Name = "尺寸D1")]
        public double? Size_D1 { get; set; }

        [Display(Name = "尺寸T2")]
        public double? Size_T2 { get; set; }

        [Display(Name = "尺寸d11")]
        public double? Size_d11 { get; set; }

        [Display(Name = "油孔d1")]
        public double? OilHole_d1 { get; set; }

        [Display(Name = "油孔数量")]
        public double? NumberOfOilHole { get; set; }

        [Display(Name = "尺寸rsmin")]
        public double? Size_rsmin { get; set; }

        [Display(Name = "尺寸r1min")]
        public double? Size_r1min { get; set; }

        [Display(Name = "预紧力力矩")]
        public double? PreloadTorque { get; set; }

        [Display(Name = "基本额定动载荷")]
        public double? BasicRatedDynamicLoad { get; set; }

        [Display(Name = "基本额定静载荷")]
        public double? BasicRatedStaticLoad { get; set; }

        [Display(Name = "脂润滑极限转速")]
        public double? SpeedLimitOfGrease { get; set; }

        [Display(Name = "油润滑极限转速")]
        public double? SpeedLimitOfOil { get; set; }

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
