using System;
using System.Collections.Generic;

#nullable disable

namespace Aircnc_BackStage.Models
{
    public partial class RoomImg
    {
        public int RoomImgId { get; set; }
        public int RoomId { get; set; }
        public string ImageUrl { get; set; }
        public int Sort { get; set; }
        public DateTime CreateTime { get; set; }

        public virtual Room Room { get; set; }
    }
}
