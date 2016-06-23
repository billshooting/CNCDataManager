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
        public string TypeID { get; set; }

        [StringLength(50)]
        public string Manufacturer { get; set; }

        [StringLength(25)]
        public string SizeOfWorkingTable { get; set; }

        public double? HeightOfWorkingTable { get; set; }

        [StringLength(25)]
        public string SizeOfCentrallyLocatedHole { get; set; }

        public double? WidthOfTableTSlot { get; set; }

        [StringLength(25)]
        public string TotalDriveRatio { get; set; }

        public double? MiniScaleUnit { get; set; }

        public double? TorqueOfServoMotor { get; set; }

        public double? PowerOfServoMotor { get; set; }

        [StringLength(25)]
        public string PitchAccuracy { get; set; }

        [StringLength(25)]
        public string RepeatAccuracy { get; set; }

        public double? LevelCarryingCapacity { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }
    }
}
