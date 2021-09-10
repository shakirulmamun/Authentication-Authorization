namespace AspNetMvcWebApp1Role.Models.Db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblProduct")]
    public partial class TblProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        public int? Qty { get; set; }
    }
}
