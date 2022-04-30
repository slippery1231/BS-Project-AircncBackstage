using System;
using System.Collections.Generic;

#nullable disable

namespace Aircnc_BackStage.Models
{
    public partial class PreOrder
    {
        public int PreOrderId { get; set; }
        public DateTime BookingDateTime { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public DateTime CkeckIn { get; set; }
        public DateTime CkeckOut { get; set; }
        public int GuestCount { get; set; }
        public decimal OriginalPrice { get; set; }
    }
}
