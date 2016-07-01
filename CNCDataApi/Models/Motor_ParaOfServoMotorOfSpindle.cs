namespace CNCDataApi.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table(name: "Motor_ParaOfServoMotorOfSpindle")]
    public partial class SpindleSrvMotorPara
    {
        [Key]
        [StringLength(50)]
        [Display(Name = "�ͺ�")]
        public string TypeID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "��������")]
        public string Manufacturer { get; set; }

        [Display(Name = "�ת��")]
        public double? RatedTorque { get; set; }

        [Display(Name = "���ת��")]
        public double? MaxTorque { get; set; }

        [Display(Name = "��ٶ�")]
        public int? RatedRotationSpeed { get; set; }

        [Display(Name = "���ת��")]
        public int? MaxRotationSpeed { get; set; }

        [Display(Name = "ת������")]
        public double? MomentOfInertia { get; set; }

        [Display(Name = "�����")]
        public double? RatedPower { get; set; }

        [Display(Name = "�����")]
        public double? RatedCurrent { get; set; }

        [Display(Name = "������")]
        public double? MaxCurrent { get; set; }

        [Display(Name = "˵��")]
        public double? Weight { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "˵��")]
        public string Description { get; set; }

        [JsonIgnore]
        [Display(Name = "����ϵͳ�ŷ�����ߴ�����")]
        public virtual SpindleSrvMotorSize Motor_SizeOfServoMotorOfSpindle { get; set; }
    }
}
