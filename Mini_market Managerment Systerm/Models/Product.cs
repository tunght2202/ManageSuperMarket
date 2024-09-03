using System;
using System.Collections.Generic;

namespace Mini_market_Managerment_Systerm.Models
{
    public partial class Product
    {
        public int ProdId { get; set; }
        public int CatId { get; set; }
        public string ProdName { get; set; } = null!;
        public int ProdPrice { get; set; }
        public int? ProdQty { get; set; }
        public int? Total { get; set; }
        public virtual Category Cat { get; set; } = null!;
    }
}
