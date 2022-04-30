using System;
using System.Collections.Generic;

#nullable disable

namespace Aircnc_BackStage.Models
{
    public partial class BankVerification
    {
        public BankVerification()
        {
            Users = new HashSet<User>();
        }

        public int BankVerificationId { get; set; }
        public int Status { get; set; }
        public string BankAccount { get; set; }
        public DateTime ApplyTime { get; set; }
        public DateTime CertificationTime { get; set; }
        public int AdminId { get; set; }
        public string BankbookImg { get; set; }

        public virtual Admin Admin { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
