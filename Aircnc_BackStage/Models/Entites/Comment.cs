using System;
using System.Collections.Generic;

#nullable disable

namespace Aircnc_BackStage.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public string CommentContent { get; set; }
        public double Stars { get; set; }
        public DateTime CreateTime { get; set; }

        public virtual Room Room { get; set; }
        public virtual User User { get; set; }
    }
}
