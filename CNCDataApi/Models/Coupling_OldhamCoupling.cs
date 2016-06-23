namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table(name: "Coupling_OldhamCoupling")]
    public partial class OldhamCoup
    {
        [Key]
        [StringLength(50)]
        public string TypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Manufacturer { get; set; }

        public double? Size_d1 { get; set; }

        public double? NominalTorque { get; set; }

        public double? AllowableRotationSpeed { get; set; }

        public double? Size_D0 { get; set; }

        public double? Size_D { get; set; }

        public double? Size_L { get; set; }

        public double? Size_h { get; set; }

        public double? Size_d2 { get; set; }

        public double? Size_c { get; set; }

        public double? Mass { get; set; }

        public double? MomentOfInertia { get; set; }

        public double? Stiffness { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }
    }
}
