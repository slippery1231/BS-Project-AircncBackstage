using System;
using System.Collections.Generic;

#nullable disable

namespace Aircnc_BackStage.Models
{
    public partial class RoomServiceLabel
    {
        public int RoomServiceLabelId { get; set; }
        public int RoomId { get; set; }
        public int TypeOfLabel { get; set; }

        public virtual Room Room { get; set; }
    }
}
