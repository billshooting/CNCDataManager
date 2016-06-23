namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table(name: "Gear_StraightBevelGear")]
    public partial class StraightBevelGear
    {
        [Key]
        [StringLength(50)]
        public string TypeID { get; set; }

        [StringLength(50)]
        public string Manufacturer { get; set; }

        public double? Modulus_m { get; set; }

        public double? PressureAngle_α { get; set; }

        public int? NumberOfTeeth_z { get; set; }

        public double? EquivalentNumberOfTeeth_zv { get; set; }

        public double? PitchAngle_δ { get; set; }

        public double? TopBevelAngle_δa { get; set; }

        public double? RootBevelAngle_δf { get; set; }

        public double? AddendumAngle_θa { get; set; }

        public double? DedendumAngle_θf { get; set; }

        public double? AddendumCoefficient { get; set; }

        public double? HeadspaceCoefficient { get; set; }

        public double? Headspace_c { get; set; }

        public double? DiameterOfPitchCircle_d { get; set; }

        public double? Addendum_ha { get; set; }

        public double? Dedendum_hf { get; set; }

        public double? DiameterOfAddendumCircle_da { get; set; }

        public double? DiameterOfDedendumCircle_df { get; set; }

        public double? ConeDistance_R { get; set; }

        public double? ThicknessOfPicthCircleTeeth_s { get; set; }

        public double? HardnessOfTeeth { get; set; }

        [StringLength(5)]
        public string GearAccuracyClass { get; set; }

        [StringLength(25)]
        public string Material { get; set; }

        [StringLength(25)]
        public string HeatTreatment { get; set; }

        public double? GearTransmissionEfficiency_η { get; set; }

        public double? MomentOfInertia { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }
    }
}
