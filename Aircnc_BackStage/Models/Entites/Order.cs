using System;
using System.Collections.Generic;

#nullable disable

namespace Aircnc_BackStage.Models
{
    public partial class Order
    {
        public Order()
        {
            TransactionStatuses = new HashSet<TransactionStatus>();
        }

        public int OrderId { get; set; }
        public DateTime BookingDateTime { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime CkeckIn { get; set; }
        public DateTime CkeckOut { get; set; }
        public int PaymentType { get; set; }
        public int Status { get; set; }
        public decimal? Discount { get; set; }
        public int BedCount { get; set; }
        public int RoomCount { get; set; }
        public int GuestCount { get; set; }
        public decimal OriginalPrice { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string District { get; set; }
        public string RoomName { get; set; }

        public virtual Room Room { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<TransactionStatus> TransactionStatuses { get; set; }
    }
}
