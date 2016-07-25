namespace CNCDataManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("数控系统功能选项_TAB")]
    public partial class NCSystemFunctionalOptions
    {
        [Key]
        [StringLength(50)]
        [Column("型号")]
        public string TypeID { get; set; }

        [StringLength(100)]
        [Column("功能选项")]
        public string FunctionalOptions { get; set; }
    }
}
