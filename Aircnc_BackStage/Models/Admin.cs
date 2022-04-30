using System;
using System.Collections.Generic;

#nullable disable

namespace Aircnc_BackStage.Models
{
    public partial class Admin
    {
        public Admin()
        {
            BankVerifications = new HashSet<BankVerification>();
            TransactionStatuses = new HashSet<TransactionStatus>();
            UserVerifications = new HashSet<UserVerification>();
        }

        public int AdminId { get; set; }
        public string AccountName { get; set; }
        public string Password { get; set; }
        public int Permission { get; set; }

        public virtual ICollection<BankVerification> BankVerifications { get; set; }
        public virtual ICollection<TransactionStatus> TransactionStatuses { get; set; }
        public virtual ICollection<UserVerification> UserVerifications { get; set; }
    }
}
