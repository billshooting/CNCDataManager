namespace CNCDataManager.APIs.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CNCSystem")]
    public partial class NCSystem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "�ͺ�")]
        [Column(name: "ModelNum")]
        public string TypeID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "��������")]
        public string Manufacturer { get; set; }

        [StringLength(50)]
        [Display(Name = "ϵ��")]
        public string series { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "֧�ֻ�������")]
        [Column(name: "MachineType")]
        public string SupportMachineType { get; set; }

        [Display(Name = "֧��ͨ����")]
        [Column(name: "Channels")]
        public int? SupportChannels { get; set; }

        [Display(Name = "����������������")]
        [Column(name: "FeedShafts")]
        public int? MaxNumberOfFeedShafts { get; set; }

        [Display(Name = "��������������")]
        [Column(name: "Spindels")]
        public int? MaxNumberOfSpindels { get; set; }

        [Display(Name = "���������")]
        [Column(name: "LinkageAxes")]
        public int? MaxNumberOfLinkageAxis { get; set; }

        public bool? IsMask { get; set; }

        [StringLength(500)]
        public string PictureUrl { get; set; }
    }
}
