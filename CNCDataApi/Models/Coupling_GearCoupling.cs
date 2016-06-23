namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table(name: "Coupling_GearCoupling")]
    public partial class GearCoup
    {
        [Key]
        [StringLength(50)]
        public string TypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Manufacturer { get; set; }

        public double? NominalTorque { get; set; }

        public double? AllowableRotationSpeed { get; set; }

        public double? DiameterOfShaftHole_d1 { get; set; }

        public double? DiameterOfShaftHole_d2 { get; set; }

        public double? DiameterOfShaftHole_dz { get; set; }

        public double? LengthOfYTypedShaftHole_L { get; set; }

        public double? LengthOfJJ1TypedShaftHoleL { get; set; }

        public double? Size_D { get; set; }

        public double? Size_D1 { get; set; }

        public double? Size_D2 { get; set; }

        public double? Size_B { get; set; }

        public double? Size_A { get; set; }

        public double? Size_C { get; set; }

        public double? Size_C1 { get; set; }

        public double? Size_C2 { get; set; }

        public double? Size_e { get; set; }

        public double? Mass { get; set; }

        public double? MomentOfInertia { get; set; }

        public double? Stiffness { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }
    }
}
