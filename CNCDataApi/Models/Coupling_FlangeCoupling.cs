namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table(name: "Coupling_FlangeCoupling")]
    public partial class FlangeCoup
    {
        [Key]
        [StringLength(50)]
        public string TypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Manufacturer { get; set; }

        public double? NominalTorque { get; set; }

        public double? AllowableRotationSpeed_Steel { get; set; }

        public double? AllowableRotationSpeed_Iron { get; set; }

        public double? DiameterOfShaftHole_d { get; set; }

        public double? LengthOfYTypedShaftHole_L { get; set; }

        public double? LengthOfJJ1TypedShaftHole_L { get; set; }

        public double? Size_D { get; set; }

        public double? Size_D1 { get; set; }

        public int? NumberOfBolts { get; set; }

        [StringLength(10)]
        public string DiameterOfBolts { get; set; }

        public double? SizeOfYTyped_L0 { get; set; }

        public double? SizeOfJJ1Typed_L0 { get; set; }

        public double? Mass { get; set; }

        public double? MomentOfInertia { get; set; }

        public double? Stiffness { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }
    }
}
