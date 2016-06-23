namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table(name: "Bearings_DoubleRowCylindricalRollerBearings")]
    public partial class DoubleRowCylinRollerBrg
    {
        [Key]
        [StringLength(50)]
        public string TypeID { get; set; }

        [StringLength(50)]
        public string Manufacturer { get; set; }

        public double? BasicRatedDynamicLoad { get; set; }

        public double? BasicRatedStaticLoad { get; set; }

        public double? SpeedLimitOfGrease { get; set; }

        public double? SpeedLimitOfOil { get; set; }

        public double? Size_d { get; set; }

        public double? Size_Dd { get; set; }

        public double? Size_B { get; set; }

        public double? Size_Ew { get; set; }

        public double? Size_r { get; set; }

        public double? Size_da { get; set; }

        public double? Size_da1 { get; set; }

        public double? Size_Damax { get; set; }

        public double? Size_Damin { get; set; }

        public double? Size_Ra { get; set; }

        public double? Mass { get; set; }

        public double? BearingAxialStiffness { get; set; }

        public double? BearingStartingTorque { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }
    }
}
