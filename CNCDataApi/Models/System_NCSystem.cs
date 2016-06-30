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
        [Display(Name ="型号")]
        public string TypeID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "生产厂家")]
        public string Manufacturer { get; set; }

        [StringLength(50)]
        [Display(Name = "支持机床类型")]
        public string SupportTypeOfMachine { get; set; }

        [Display(Name = "支持通道数")]
        public int? SupportNumberOfChannels { get; set; }

        [Display(Name = "进给轴最大控制轴数")]
        public int? MaxControlNumberOfFeedAxis { get; set; }

        [Display(Name = "主轴最大控制轴数")]
        public int? MaxControlNumberOfSpindle { get; set; }

        [Display(Name = "最大联轴数")]
        public int? MaxNumberOfLinkageAxis { get; set; }

        //[Display(Name = "图片")]
        //public byte[] CNCImage { get; set; }
    }
}
