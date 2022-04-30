using System;
using System.Collections.Generic;

#nullable disable

namespace Aircnc_BackStage.Models
{
    public partial class UserVerification
    {
        public UserVerification()
        {
            Users = new HashSet<User>();
        }

        public int UserVerificationId { get; set; }
        public int DocumentType { get; set; }
        public int Status { get; set; }
        public DateTime ApplyTime { get; set; }
        public DateTime? CertificationTime { get; set; }
        public int AdminId { get; set; }
        public string IdPhoto { get; set; }

        public virtual Admin Admin { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
