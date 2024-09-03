using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mini_market_Managerment_Systerm.Models
{
    public partial class Bill
    {
        [Key]
        public int BillId { get; set; }
        public string SellerName { get; set; } = null!;
        public DateTime BillDate { get; set; }
        public int TotalAmount { get; set; }
    }
}
