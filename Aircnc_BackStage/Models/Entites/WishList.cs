using System;
using System.Collections.Generic;

#nullable disable

namespace Aircnc_BackStage.Models
{
    public partial class WishList
    {
        public int WishListId { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime CreateTime { get; set; }

        public virtual Room Room { get; set; }
        public virtual User User { get; set; }
    }
}
