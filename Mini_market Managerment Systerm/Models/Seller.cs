using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mini_market_Managerment_Systerm.Models
{
    public partial class Seller
    {
        [Key]
        public int SellerId { get; set; }
        public int UserId { get; set; }
        public string SellerName { get; set; } = null!;
        public int SellerAge { get; set; }
        public string SellerPhone { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
