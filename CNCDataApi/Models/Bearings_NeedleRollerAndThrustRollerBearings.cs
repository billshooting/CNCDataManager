namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table(name: "Bearings_NeedleRollerAndThrustRollerBearings")]
    public partial class NeedleThrustRollerBrg
    {
        [Key]
        [StringLength(50)]
        public string TypeID { get; set; }

        [StringLength(50)]
        public string Manufacturer { get; set; }

        public double? InnerDiameter_d { get; set; }

        public double? Diameter_D { get; set; }

        public double? Width_T { get; set; }

        public double? Size_T1 { get; set; }

        public double? Size_C { get; set; }

        public double? Size_D1 { get; set; }

        public double? Size_T2 { get; set; }

        public double? Size_d11 { get; set; }

        public double? OilHole_d1 { get; set; }

        public double? NumberOfOilHole { get; set; }

        public double? Size_rsmin { get; set; }

        public double? Size_r1min { get; set; }

        public double? PreloadTorque { get; set; }

        public double? BasicRatedDynamicLoad { get; set; }

        public double? BasicRatedStaticLoad { get; set; }

        public double? SpeedLimitOfGrease { get; set; }

        public double? SpeedLimitOfOil { get; set; }

        public double? Mass { get; set; }

        public double? BearingAxialStiffness { get; set; }

        public double? BearingStartingTorque { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }
    }
}
