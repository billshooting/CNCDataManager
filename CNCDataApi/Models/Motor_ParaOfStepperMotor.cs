namespace CNCDataApi.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table(name: "Motor_ParaOfStepperMotor")]
    public partial class StepMotorPara
    {
        [Key]
        [StringLength(50)]
        [Display(Name = "�ͺ�")]
        public string TypeID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "��������")]
        public string Manufacturer { get; set; }

        [Display(Name = "�������")]
        public double? TypeOfMotor { get; set; }

        [Display(Name = "�����")]
        public double? AngleOfStep { get; set; }

        [Display(Name = "����")]
        public int? NumberOfPhase { get; set; }

        [Display(Name = "����")]
        public int? Pace { get; set; }

        [Display(Name = "��λת��")]
        public double? PositionTorque { get; set; }

        [Display(Name = "����ת��")]
        public double? HoldingTorque { get; set; }

        [StringLength(25)]
        [Display(Name = "����Ǿ���")]
        public string StepAngleAccuracy { get; set; }

        [Display(Name = "���ϵ��")]
        public double? InductanceCoefficient { get; set; }

        [Display(Name = "���ѹ")]
        public double? RatedVoltage { get; set; }

        [Display(Name = "�����")]
        public double? RatedCurrency { get; set; }

        [Display(Name = "�������")]
        public double? WindingResistance { get; set; }

        [Display(Name = "�������¶�")]
        public double? AllowableWorkingTemperature { get; set; }

        [Display(Name = "������")]
        public int? NumberOfLeads { get; set; }

        [Display(Name = "ת������")]
        public double? MomentOfInertia { get; set; }

        [Display(Name = "����")]
        public double? Mass { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "˵��")]
        public string Description { get; set; }

        [JsonIgnore]
        [Display(Name = "��������ߴ�")]
        public virtual StepMotorSize Motor_SizeOfStepperMotor { get; set; }
    }
}
