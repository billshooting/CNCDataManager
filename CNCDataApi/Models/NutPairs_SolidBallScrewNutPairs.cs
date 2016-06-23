namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table(name: "NutPairs_SolidBallScrewNutPairs")]
    public partial class SolidBallScrewNutPairs
    {
        [Key]
        [StringLength(50)]
        public string TypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Manufacturer { get; set; }

        public double? BasicRatedDynamicLoad_Ca { get; set; }

        public double? BasicRatedStaticLoad_Coa { get; set; }

        public double? Stiffness { get; set; }

        public double? NominalDiameter_d0 { get; set; }

        public double? NominalLead_Ph0 { get; set; }

        public double? OuterDiameterOfScrew_d1 { get; set; }

        public double? DiameterOfSteelBall_DW { get; set; }

        public double? BottomDiameterOfScrew_d2 { get; set; }

        public double? AdaptableDiameterWithBearing { get; set; }

        public double? AdaptableDiameterWithCouplingShaftHole { get; set; }

        public int? LimitRotationSpeed { get; set; }

        public double? DistanceBetweenTwoPushBearings { get; set; }

        public double? LengthOfScrew_L { get; set; }

        public int? TotalCycleTurns_n { get; set; }

        public double? Size_D3 { get; set; }

        public double? Size_D4 { get; set; }

        public double? Size_D5 { get; set; }

        public double? Size_D6 { get; set; }

        public double? Size_D7 { get; set; }

        public double? Size_L1 { get; set; }

        public int? NumberOfScrewHoles_m { get; set; }

        public double? Density { get; set; }

        public double? ElasticModulus { get; set; }

        public double? ShearElasticModulus { get; set; }

        public double? RadialDampingCoefficient { get; set; }

        public double? ViscousFrictionFactor { get; set; }

        public double? EfficiencyOfBallScrewPreload { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }
    }
}
