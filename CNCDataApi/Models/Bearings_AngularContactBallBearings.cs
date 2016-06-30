namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table(name: "Bearings_AngularContactBallBearings")]
    public partial class AngContactBallBrg
    {
        [Key]
        [StringLength(50)]
        [Display(Name = "型号")]
        public string TypeID { get; set; }

        [Display(Name = "生产厂家")]
        [StringLength(50)]
        public string Manufacturer { get; set; }

        [Display(Name = "接触角Alpha")]
        public double? ContactAngle_Alpha { get; set; }

        [Display(Name = "内径d")]
        public double? InnerDiameter_d { get; set; }

        [Display(Name = "直径D")]
        public double? Diameter_D { get; set; }

        [Display(Name = "宽度B")]
        public double? Width_B { get; set; }

        [Display(Name = "尺寸a")]
        public double? Size_a { get; set; }

        [Display(Name = "尺寸rsmin")]
        public double? Size_rsmin { get; set; }

        [Display(Name = "尺寸r1smin")]
        public double? Size_r1smin { get; set; }

        [Display(Name = "尺寸damin")]
        public double? Size_damin { get; set; }

        [Display(Name = "尺寸Damax")]
        public double? Size_Damax { get; set; }

        [Display(Name = "尺寸rasmax")]
        public double? Size_rasmax { get; set; }

        [Display(Name = "基本额定动载荷")]
        public double? BasicRatedDynamicLoad { get; set; }

        [Display(Name = "基本额定静载荷")]
        public double? BasicRatedStaticLoad { get; set; }

        [Display(Name = "脂润滑极限速度")]
        public double? SpeedLimitOfGrease { get; set; }

        [Display(Name = "油润滑极限速度")]
        public double? SpeedLimitOfOil { get; set; }

        [Display(Name = "轴承轴向刚度")]
        public double? BearingAxialStiffness { get; set; }

        [Display(Name = "轴承启动转矩")]
        public double? BearingStartingTorque { get; set; }

        [Display(Name = "说明")]
        [Column(TypeName = "text")]
        public string Description { get; set; }
    }
}
