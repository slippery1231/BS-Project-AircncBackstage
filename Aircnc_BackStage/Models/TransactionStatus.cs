using System;
using System.Collections.Generic;

#nullable disable

namespace Aircnc_BackStage.Models
{
    public partial class TransactionStatus
    {
        public int TransactionStatusId { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public DateTime CreateTime { get; set; }
        public int AdminId { get; set; }
        public decimal TotalAmount { get; set; }
        public int StatusType { get; set; }

        public virtual Admin Admin { get; set; }
        public virtual Order Order { get; set; }
        public virtual User User { get; set; }
    }
}
