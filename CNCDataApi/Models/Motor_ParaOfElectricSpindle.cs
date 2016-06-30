namespace CNCDataApi.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table(name: "ParaOfElectricSpindle")]
    public partial class ElecSpindlePara
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

        [Display(Name = "�ת��")]
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

        [Display(Name = "ֱ��ĸ�ߵ�ѹ")]
        public double? DCLinkVoltage { get; set; }

        [Display(Name = "���綯��ϵ��")]
        public double? BackEMFCoefficient { get; set; }

        [Display(Name = "��ʱ�䳣��")]
        public double? ThermalTimeConstant { get; set; }

        [Display(Name = "ת������")]
        public double? MassOfRotor { get; set; }

        [Display(Name = "��������")]
        public double? MassOfStator { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "˵��")]
        public string Description { get; set; }


        [Display(Name = "������ߴ�����")]
        public virtual ElecSpindleSize Motor_SizeOfElectricSpindle { get; set; }
    }
}
