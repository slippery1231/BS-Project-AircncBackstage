using Aircnc_BackStage.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aircnc_BackStage.Models.ViewModels
{
    public class HomePageViewModel
    {
        public int RoomCount { get; set; }
        public int UserCount { get; set; }

        public int LastMonthIncome { get; set; }
        public int ThisMonthIncome { get; set; }
        public int ThisMonthRoom { get; set; }
        public int ThisMonthUser{ get; set; }
        public int TodayRoom { get; set; }
        public int TodayUser { get; set; }
        public int TodayIncome { get; set; }
       
    }
}
