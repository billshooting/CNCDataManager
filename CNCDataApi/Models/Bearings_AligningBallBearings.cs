namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bearings_AligningBallBearings
    {
        [Key]
        [StringLength(50)]
        [Display(Name ="型号")]
        public string TypeNo { get; set; }

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

        [Display(Name = "尺寸damin")]
        public double? Size_damin { get; set; }

        [Display(Name = "尺寸Damax")]
        public double? Size_Damax { get; set; }

        [Display(Name = "尺寸rasmax")]
        public double? Size_rasmax { get; set; }

        [Display(Name = "e")]
        public double? e { get; set; }

        [Display(Name = "Y1")]
        public double? Y1 { get; set; }

        [Display(Name = "Y2")]
        public double? Y2 { get; set; }

        [Display(Name = "Yo")]
        public double? Yo { get; set; }

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
