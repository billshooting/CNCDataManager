namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table(name: "Bearings_TaperedRollerBearings")]
    public partial class TaperedRollerBrg
    {
        [Key]
        [StringLength(50)]
        [Display(Name = "型号")]
        public string TypeID { get; set; }

        [StringLength(50)]
        [Display(Name = "生产厂家")]
        public string Manufacturer { get; set; }

        [Display(Name = "内径d")]
        public double? InnerDiameter_d { get; set; }

        [Display(Name = "直径D")]
        public double? Diameter_D { get; set; }

        [Display(Name = "宽度T")]
        public double? Width_T { get; set; }

        [Display(Name = "尺寸B")]
        public double? Size_B { get; set; }

        [Display(Name = "尺寸C")]
        public double? Size_C { get; set; }

        [Display(Name = "尺寸a")]
        public double? Size_a { get; set; }

        [Display(Name = "尺寸rsmin")]
        public double? Size_rsmin { get; set; }

        [Display(Name = "尺寸r1smin")]
        public double? Size_r1smin { get; set; }

        [Display(Name = "尺寸damin")]
        public double? Size_damin { get; set; }

        [Display(Name = "尺寸dbmax")]
        public double? Size_dbmax { get; set; }

        [Display(Name = "尺寸Damax")]
        public double? Size_Damax { get; set; }

        [Display(Name = "尺寸Dbmin")]
        public double? Size_Dbmin { get; set; }

        [Display(Name = "尺寸a1min")]
        public double? Size_a1min { get; set; }

        [Display(Name = "尺寸a2min")]
        public double? Size_a2min { get; set; }

        [Display(Name = "尺寸rasmax")]
        public double? Size_rasmax { get; set; }

        [Display(Name = "尺寸rbsmax")]
        public double? Size_rbsmax { get; set; }

        [Display(Name = "e")]
        public double? e { get; set; }

        [Display(Name = "Y")]
        public double? Y { get; set; }

        [Display(Name = "Yo")]
        public double? Yo { get; set; }

        [Display(Name = "基本额定动载荷")]
        public double? BasicRatedDynamicLoad { get; set; }

        [Display(Name = "基本额定静载荷")]
        public double? BasicRatedStaticLoad { get; set; }

        [Display(Name = "脂润滑极限转速")]
        public double? SpeedLimitOfGrease { get; set; }

        [Display(Name = "油润滑极限转速")]
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
