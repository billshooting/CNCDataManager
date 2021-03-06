namespace CNCDataManager.APIs.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "角接触球轴承数据_TAB")]
    public partial class AngContactBallBrg
    {
        [Key]
        [StringLength(50)]
        [Column(name: "型号")]
        public string TypeID { get; set; }

        [StringLength(50)]
        [Column(name: "生产厂家")]
        public string Manufacturer { get; set; }

        [Column(name: "接触角α")]
        public double? ContactAngle_Alpha { get; set; }

        [Column(name: "内径d")]
        public double? InnerDiameter_d { get; set; }

        [Column(name: "直径D")]
        public double? Diameter_D { get; set; }

        [Column(name: "宽B")]
        public double? Width_B { get; set; }

        [Column(name: "尺寸a")]
        public double? Size_a { get; set; }

        [Column(name: "尺寸rsmin")]
        public double? Size_rsmin { get; set; }

        [Column(name: "尺寸r1smin")]
        public double? Size_r1smin { get; set; }

        [Column(name: "尺寸damin")]
        public double? Size_damin { get; set; }

        [Column(name: "尺寸Damax")]
        public double? Size_Damax { get; set; }

        [Column(name: "尺寸rasmax")]
        public double? Size_rasmax { get; set; }

        [Column(name: "基本额定动负荷")]
        public double? BasicRatedDynamicLoad { get; set; }

        [Column(name: "基本额定静负荷")]
        public double? BasicRatedStaticLoad { get; set; }

        [Column(name: "脂极限转速")]
        public double? SpeedLimitOfGrease { get; set; }

        [Column(name: "油极限转速")]
        public double? SpeedLimitOfOil { get; set; }

        [Column(name: "轴承轴向刚度")]
        public double? BearingAxialStiffness { get; set; }

        [Column(name: "轴承启动力矩")]
        public double? BearingStartingTorque { get; set; }

        [Column(name: "说明", TypeName = "text")]
        public string Description { get; set; }
    }
}
