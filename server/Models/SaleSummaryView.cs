using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppApi.Models
{
    [Table("SaleSummaryView")]
    public class SaleSummaryView
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("OrderID")]
        public int OrderID { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductCategory { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        public short OrderQty { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal LineTotal { get; set; }

        public int SalesPersonID { get; set; }

        [StringLength(200)] 
        public string SalesPersonName { get; set; }

        [StringLength(200)] 
        public string ShippingAddress { get; set; }

        [StringLength(200)] 
        public string BillingAddress { get; set; }
    }
}
