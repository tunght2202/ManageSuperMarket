using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mini_market_Managerment_Systerm.Models
{
    public partial class User
    {
        [Key]
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; } = null!;
        public string UserPass { get; set; } = null!;

        public virtual Role Role { get; set; } = null!;
    }
}
