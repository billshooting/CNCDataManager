namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table(name: "Table_RotaryTable")]
    public partial class RotaryTable
    {
        [Key]
        [StringLength(50)]
        [Display(Name = "型号")]
        public string TypeID { get; set; }

        [StringLength(50)]
        [Display(Name = "生产厂家")]
        public string Manufacturer { get; set; }

        [StringLength(25)]
        [Display(Name = "工作台尺寸")]
        public string SizeOfWorkingTable { get; set; }

        [Display(Name = "工作台高度")]
        public double? HeightOfWorkingTable { get; set; }

        [StringLength(25)]
        [Display(Name = "中心定位孔尺寸")]
        public string SizeOfCentrallyLocatedHole { get; set; }

        [Display(Name = "工作台T形槽宽度")]
        public double? WidthOfTableTSlot { get; set; }

        [StringLength(25)]
        [Display(Name = "总传动比")]
        public string TotalDriveRatio { get; set; }

        [Display(Name = "最小分度单位")]
        public double? MiniScaleUnit { get; set; }

        [Display(Name = "伺服电机转矩")]
        public double? TorqueOfServoMotor { get; set; }

        [Display(Name = "伺服电机功率")]
        public double? PowerOfServoMotor { get; set; }

        [StringLength(25)]
        [Display(Name = "分度精度")]
        public string PitchAccuracy { get; set; }

        [StringLength(25)]
        [Display(Name = "重复精度")]
        public string RepeatAccuracy { get; set; }

        [Display(Name = "水平承载能力")]
        public double? LevelCarryingCapacity { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "说明")]
        public string Description { get; set; }
    }
}
