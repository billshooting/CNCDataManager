namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table(name: "Bearings_CylindricalRollerBearings")]
    public partial class CylinRollerBrg
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

        [Display(Name = "宽度B")]
        public double? Width_B { get; set; }

        [Display(Name = "尺寸rsmin")]
        public double? Size_rsmin { get; set; }

        [Display(Name = "尺寸r1smin")]
        public double? Size_r1smin { get; set; }

        [Display(Name = "尺寸D1max")]
        public double? Size_D1max { get; set; }

        [Display(Name = "尺寸D2max")]
        public double? Size_D2max { get; set; }

        [Display(Name = "尺寸D3max")]
        public double? Size_D3max { get; set; }

        [Display(Name = "尺寸D4max")]
        public double? Size_D4max { get; set; }

        [Display(Name = "尺寸D5max")]
        public double? Size_D5max { get; set; }

        [Display(Name = "尺寸rasmax")]
        public double? Size_rasmax { get; set; }

        [Display(Name = "尺寸rbsmax")]
        public double? Size_rbsmax { get; set; }

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

        [Column(TypeName = "text")]
        [Display(Name = "说明")]
        public string Description { get; set; }
    }
}
