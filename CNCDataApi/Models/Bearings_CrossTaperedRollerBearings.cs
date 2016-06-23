namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table(name: "Bearings_CrossTaperedRollerBearings")]
    public partial class XTaperedRollerBrg
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

        public double? InnerDiameter_d { get; set; }

        public double? Diameter_D { get; set; }

        public double? Width_T { get; set; }

        public double? Size_c { get; set; }

        public double? Size_r { get; set; }

        public double? Size_d1 { get; set; }

        public double? Size_Dd1 { get; set; }

        public double? Size_ra { get; set; }

        public double? Mass { get; set; }

        public double? BearingAxialStiffness { get; set; }

        public double? BearingStartingTorque { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }
    }
}
