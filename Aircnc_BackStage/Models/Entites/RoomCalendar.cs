using System;
using System.Collections.Generic;

#nullable disable

namespace Aircnc_BackStage.Models
{
    public partial class RoomCalendar
    {
        public int RoomCalendarId { get; set; }
        public int RoomId { get; set; }
        public DateTime Date { get; set; }
        public DateTime LastChangeTime { get; set; }
        public int RoomCalendarStatus { get; set; }
        public decimal UnitPrice { get; set; }
        public string Note { get; set; }

        public virtual Room Room { get; set; }
    }
}
