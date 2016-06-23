namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table(name: "Coupling_HubShapedCouplings")]
    public partial class HubShapedCoup
    {
        [Key]
        [StringLength(50)]
        public string TypeID { get; set; }

        [StringLength(50)]
        public string Manufacturer { get; set; }

        public double? NominalTorque { get; set; }

        public double? AllowableRotationSpeed { get; set; }

        [StringLength(10)]
        public string DiameterOfShaftHole_d1 { get; set; }

        [StringLength(10)]
        public string DiameterOfShaftHole_d2 { get; set; }

        public double? DiameterOfShaftHole_L1 { get; set; }

        public double? DiameterOfShaftHole_L2 { get; set; }

        public double? Size_L0 { get; set; }

        public double? Size_D { get; set; }

        public double? Size_D1 { get; set; }

        public double? Size_D2 { get; set; }

        public double? Size_E { get; set; }

        public double? Size_S { get; set; }

        public double? MomentOfInertia { get; set; }

        public double? Weight { get; set; }

        public double? Stiffness { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }
    }
}
