namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table(name: "Bearings_DoubleThrustAngularContactBallBearings")]
    public partial class DoubleThrustAngContactBallBrg
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

        [Display(Name = "尺寸d1")]
        public double? Size_d1 { get; set; }

        [Display(Name = "宽度H")]
        public double? Width_H { get; set; }

        [Display(Name = "尺寸A")]
        public double? Size_A { get; set; }

        [Display(Name = "尺寸r")]
        public double? Size_r { get; set; }

        [Display(Name = "尺寸r1min")]
        public double? Size_r1min { get; set; }

        [Display(Name = "尺寸W")]
        public double? Size_W { get; set; }

        [Display(Name = "尺寸dPhi")]
        public double? Size_d_Phi { get; set; }

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

        [Display(Name = "尺寸Ds")]
        public double? Size_Ds { get; set; }

        [Display(Name = "尺寸ds1")]
        public double? Size_ds1 { get; set; }

        [Display(Name = "尺寸rs")]
        public double? Size_rs { get; set; }

        [Display(Name = "尺寸rs1")]
        public double? Size_rs1 { get; set; }

        [Display(Name = "轴承轴向刚度")]
        public double? BearingAxialStiffness { get; set; }

        [Display(Name = "轴承启动转矩")]
        public double? BearingStartingTorque { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "说明")]
        public string Description { get; set; }
    }
}
