using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aircnc_BackStage.Models.Dtos
{
    public class RoomDto
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public decimal UnitPrice { get; set; }
        public string CreateTime { get; set; }
        public string Status { get; set; } //1已上架 2已下架 3建立中 4取消發布

    }
}
