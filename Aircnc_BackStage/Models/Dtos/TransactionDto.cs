using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aircnc_BackStage.Models.Dtos
{
    public class TransactionDto
    {
        public int TransactionStatusId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } //房東名字
        public int OrderId { get; set; }
        public string CreateTime { get; set; }
        //public int AdminId { get; set; }
        public decimal TotalAmount { get; set; }
        public string StatusType { get; set; }


    }
}
