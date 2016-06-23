namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table(name: "System_NCSystem")]
    public partial class NCSystem
    {
        [Key]
        [StringLength(50)]
        public string TypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Manufacturer { get; set; }

        [StringLength(50)]
        public string SupportTypeOfMachine { get; set; }

        public int? SupportNumberOfChannels { get; set; }

        public int? MaxControlNumberOfFeedAxis { get; set; }

        public int? MaxControlNumberOfSpindle { get; set; }

        public int? MaxNumberOfLinkageAxis { get; set; }

        public byte[] CNCImage { get; set; }
    }
}
