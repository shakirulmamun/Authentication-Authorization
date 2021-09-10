namespace AspNetMvcWebApp1Role.Models.Db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblCustomer")]
    public partial class TblCustomer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerID { get; set; }

        [StringLength(50)]
        public string CustomerName { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }
    }
}
