namespace CNCDataApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Motor_ParaOfServoMotorOfPMSACFS
    {
        [Key]
        [StringLength(50)]
        [Display(Name = "�ͺ�")]
        public string TypeNo { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "��������")]
        public string Manufacturer { get; set; }

        [Display(Name = "�ת��")]
        public double? RatedTorque { get; set; }

        [Display(Name = "���ת��")]
        public double? MaxTorque { get; set; }

        [Display(Name = "�ת��")]
        public int? RatedRotationSpeed { get; set; }

        [Display(Name = "���ת��")]
        public int? MaxRotationSpeed { get; set; }

        [Display(Name = "ת������")]
        public double? MomentOfInertia { get; set; }

        [Display(Name = "�����")]
        public double? RatedPower { get; set; }

        [Display(Name = "������")]
        public double? StaticTorque { get; set; }

        [Display(Name = "����ż�����")]
        public int? PairsOfMotorPole { get; set; }

        [Display(Name = "ֱ��ĸ�ߵ�ѹ")]
        public double? DCLinkVoltage { get; set; }

        [Display(Name = "�����")]
        public double? RatedCurrent { get; set; }

        [Display(Name = "������")]
        public double? MaxCurrent { get; set; }

        [Display(Name = "��е�¼�����")]
        public double? MechanicalTimeConstant { get; set; }

        [Display(Name = "����")]
        public double? Mass { get; set; }

        [Display(Name = "���ӵ���")]
        public double? StatorResistance { get; set; }

        [Display(Name = "ÿ�ྲ������©��")]
        public double? LeakageInductanceOfEachPhaseOfStatorWinding { get; set; }

        [Display(Name = "���綯��")]
        public double? CounterElectromotiveForce { get; set; }

        [Display(Name = "�Ƶ��")]
        public int? RatedFrequency { get; set; }

        [Display(Name = "���ת��ת������")]
        public double? MomentOfInertiaOfMotorRotor { get; set; }

        [Display(Name = "ÿ���������")]
        public double? ResistanceOfPhaseWinding { get; set; }

        [Display(Name = "ÿ��������")]
        public double? InductanceOfPhaseWinding { get; set; }

        [StringLength(10)]
        [Display(Name = "�Ƿ����բ")]
        public string IfWithBrake { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "˵��")]
        public string Description { get; set; }
    }
}
