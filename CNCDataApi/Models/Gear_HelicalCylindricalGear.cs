namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table(name: "Gear_HelicalCylindricalGear")]
    public partial class HeliCylinGear
    {
        [Key]
        [StringLength(10)]
        public string TypeID { get; set; }

        [StringLength(10)]
        public string Manufacturer { get; set; }

        public double? ModulusOfEndSurface_mt { get; set; }

        public double? ModulusOfNormalSurface_mn { get; set; }

        public double? PressureAngle_α { get; set; }

        public int? NumberOfTeeth_z { get; set; }

        public double? EquivalentNumberOfTeeth_zv { get; set; }

        public double? HelixAngle_β { get; set; }

        public double? AddendumCoefficient { get; set; }

        public double? HeadspaceCoefficient { get; set; }

        public double? ModificationCoefficient_χ { get; set; }

        public double? WidthOfTeeth_b { get; set; }

        public double? DiameterOfPitchCircle_d { get; set; }

        public double? DiameterOfBaseCircle_db { get; set; }

        public double? HeightOfFullTeeth_h { get; set; }

        public double? Addendum_ha { get; set; }

        public double? Dedendum_hf { get; set; }

        public double? PitchOfEndSurfaceTeeth_pt { get; set; }

        public double? PitchOfNormalSurfaceTeeth_pn { get; set; }

        public double? ThicknessOfEndSurfaceTeeth_st { get; set; }

        public double? DiameterOfAddendumCircle_da { get; set; }

        public double? DiameterOfDedendumCircle_df { get; set; }

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
