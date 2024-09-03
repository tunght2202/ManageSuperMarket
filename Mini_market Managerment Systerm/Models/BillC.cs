using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_market_Managerment_Systerm.Models
{
    public partial class BillC
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BillCid { get; set; }
        public int BillId { get; set; }
        public string ProductName { get; set; } = null!;
        public int ProductPrice { get; set; }
        public int? Quantity { get; set; }
        public int? Total { get; set; }
    }
}
