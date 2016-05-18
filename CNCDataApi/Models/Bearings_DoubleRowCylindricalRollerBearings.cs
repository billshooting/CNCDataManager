namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bearings_DoubleRowCylindricalRollerBearings
    {
        [Key]
        [StringLength(50)]
        [Display(Name = "型号")]
        public string TypeNo { get; set; }

        [StringLength(50)]
        [Display(Name = "生产厂家")]
        public string Manufacturer { get; set; }

        [Display(Name = "基本额定动载荷")]
        public double? BasicRatedDynamicLoad { get; set; }

        [Display(Name = "基本额定静载荷")]
        public double? BasicRatedStaticLoad { get; set; }

        [Display(Name = "脂润滑极限转速")]
        public double? SpeedLimitOfGrease { get; set; }

        [Display(Name = "油润滑极限转速")]
        public double? SpeedLimitOfOil { get; set; }

        [Display(Name = "尺寸d")]
        public double? Size_d { get; set; }

        [Display(Name = "尺寸Dd")]
        public double? Size_Dd { get; set; }

        [Display(Name = "尺寸B")]
        public double? Size_B { get; set; }

        [Display(Name = "尺寸Ew")]
        public double? Size_Ew { get; set; }

        [Display(Name = "尺寸r")]
        public double? Size_r { get; set; }

        [Display(Name = "尺寸da")]
        public double? Size_da { get; set; }

        [Display(Name = "尺寸da1")]
        public double? Size_da1 { get; set; }

        [Display(Name = "尺寸Damax")]
        public double? Size_Damax { get; set; }

        [Display(Name = "尺寸Damin")]
        public double? Size_Damin { get; set; }

        [Display(Name = "尺寸Ra")]
        public double? Size_Ra { get; set; }

        [Display(Name = "质量")]
        public double? Mass { get; set; }

        [Display(Name = "轴承轴向刚度")]
        public double? BearingAxialStiffness { get; set; }

        [Display(Name = "轴承启动转矩")]
        public double? BearingStartingTorque { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "说明")]
        public string Description { get; set; }
    }
}
