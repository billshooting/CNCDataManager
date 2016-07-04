namespace CNCDataApi.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("伺服驱动电抗器数据_TAB")]
    public partial class SrvDriverReactor
    {  
        [Key]
        [StringLength(50)]
        [Column("型号")]
        public string TypeID { get; set; }

        [Required]
        [StringLength(50)]
        [Column("生产厂家")]
        public string Manufacturer { get; set; }

        [Column("功率/kW")]
        public double Power { get; set; }

        [StringLength(50)]
        [Column("外形尺寸")]
        public string Dimensions { get; set; }

        [StringLength(50)]
        [Column("安装尺寸")]
        public string InstallationDimensions { get; set; }

        [StringLength(50)]
        [Column("孔径")]
        public string DiameterOfHole { get; set; }
    }
}
