namespace CNCDataApi.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table(name: "Motor_SizeOfElectricSpindle")]
    public partial class ElecSpindleSize
    {
        [Key]
        [StringLength(50)]
        [Display(Name = "�ͺ�")]
        public string TypeID { get; set; }

        [StringLength(50)]
        [Display(Name = "��������")]
        public string Manufacturer { get; set; }

        [Display(Name = "�ߴ�C")]
        public double? Size_C { get; set; }

        [Display(Name = "�ߴ�D1")]
        public double? Size_D1 { get; set; }

        [Display(Name = "�ߴ�D2")]
        public double? Size_D2 { get; set; }

        [Display(Name = "�ߴ�J")]
        public double? Size_J { get; set; }

        [Display(Name = "�ߴ�K")]
        public double? Size_K { get; set; }

        [Display(Name = "�ߴ�L")]
        public double? Size_L { get; set; }

        [Display(Name = "�ߴ�M")]
        public double? Size_M { get; set; }

        [Display(Name = "�ߴ�N")]
        public double? Size_N { get; set; }

        [JsonIgnore]
        [Display(Name = "�����Ἴ������")]
        public virtual ElecSpindlePara Motor_ParaOfElectricSpindle { get; set; }
    }
}
