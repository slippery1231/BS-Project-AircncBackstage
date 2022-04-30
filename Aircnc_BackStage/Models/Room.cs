using System;
using System.Collections.Generic;

#nullable disable

namespace Aircnc_BackStage.Models
{
    public partial class Room
    {
        public Room()
        {
            Comments = new HashSet<Comment>();
            Orders = new HashSet<Order>();
            RoomCalendars = new HashSet<RoomCalendar>();
            RoomImgs = new HashSet<RoomImg>();
            RoomServiceLabels = new HashSet<RoomServiceLabel>();
            WishLists = new HashSet<WishList>();
        }

        public int RoomId { get; set; }
        public int UserId { get; set; }
        public int HouseType { get; set; }
        public int RoomType { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Pax { get; set; }
        public int BedCount { get; set; }
        public int RoomCount { get; set; }
        public int BathroomCount { get; set; }
        public string RoomDescription { get; set; }
        public string RoomName { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? LastChangeTime { get; set; }
        public int Status { get; set; }
        public string Note { get; set; }
        public string RoomCheckInTime { get; set; }
        public string RoomCheckOutTime { get; set; }
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<RoomCalendar> RoomCalendars { get; set; }
        public virtual ICollection<RoomImg> RoomImgs { get; set; }
        public virtual ICollection<RoomServiceLabel> RoomServiceLabels { get; set; }
        public virtual ICollection<WishList> WishLists { get; set; }
    }
}
