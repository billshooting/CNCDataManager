namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table(name: "Worm_CommonCylindricalWormGear")]
    public partial class CommonCylinWormGear
    {
        [Key]
        [StringLength(50)]
        public string TypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Manufacturer { get; set; }

        public double? Modulus_m { get; set; }

        public double? ProfileAngle_α { get; set; }

        public double? CentralDistance_a { get; set; }

        public int? NumberOfWormTeeth_z1 { get; set; }

        public int? NumberOfWormGearWheelTeeth_z2 { get; set; }

        public double? DriveRatio_i { get; set; }

        public double? ModificationCoefficient_χ2 { get; set; }

        public double? DiameterOfPitchCircleOfWorm_d1 { get; set; }

        public double? AxialPitchOfWorm_px { get; set; }

        public double? LeadOfWorm_pz { get; set; }

        public double? LeadAngleOfPitchCircleOfWormWheel_γ { get; set; }

        public double? HeadSpace_c { get; set; }

        public double? WormAddendum_ha1 { get; set; }

        public double? WormDedendum_hf1 { get; set; }

        public double? TeethHeightOfWorm_h1 { get; set; }

        public double? DiameterOfAddendumCircleOfWorm_da1 { get; set; }

        public double? DiameterOfDedendumCircleOfWorm_df1 { get; set; }

        public double? LengthOfScrewThreadOfWorm_b1 { get; set; }

        public double? AxialThicknessOfWorm_Sx1 { get; set; }

        public double? NormalThicknessOfWorm_Sn1 { get; set; }

        public double? DiameterOfThroatCircleOfWormWheel_d2 { get; set; }

        public double? AddendumOfWormWheel_ha2 { get; set; }

        public double? DedendumOfWormWheel_hf2 { get; set; }

        public double? DiameterOfThroatCircleOfWormWheel_da2 { get; set; }

        public double? TeethWidthOfWormWheel_b2 { get; set; }

        public double? RadiusOfRootTeethOfWormWheel_R1 { get; set; }

        public double? RadiusOfRootTeethOfWormWheel_R2 { get; set; }

        public double? DiameterOfAddendumCircleOfWormWheel_de2 { get; set; }

        public double? FlangeWidthOfWormWheel_B { get; set; }

        public double? Length_l1 { get; set; }

        public double? Length_l2 { get; set; }

        public double? TransmissionEfficiency_η { get; set; }

        public double? ViscousFrictionOfWormShaft { get; set; }

        public double? MomentOfInertiaOfWormWheel { get; set; }

        public double? MomentOfInertiaOFWorm { get; set; }

        public double? TorsionalStiffnessOfWormShaft { get; set; }

        [StringLength(25)]
        public string Material { get; set; }

        [StringLength(25)]
        public string CastingProcess { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }
    }
}
