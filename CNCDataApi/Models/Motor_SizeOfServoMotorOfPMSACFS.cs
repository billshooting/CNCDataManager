namespace CNCDataApi.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "Motor_SizeOfServoMotorOfPMSACFS")]
    public partial class PMSrvMotorSize
    {
        [Key]
        [StringLength(50)]
        public string TypeID { get; set; }

        [StringLength(50)]
        public string Manufacturer { get; set; }

        public double? Size_B { get; set; }

        public double? Size_C { get; set; }

        public double? Size_K { get; set; }

        [StringLength(25)]
        public string Size_F { get; set; }

        public double? Size_G { get; set; }

        [StringLength(25)]
        public string Size_D { get; set; }

        public double? Size_E1 { get; set; }

        public double? Size_E2 { get; set; }

        public double? Size_E3 { get; set; }
    }
}
