using Aircnc_BackStage.Models;
using AircncFrontStage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aircnc_BackStage.Services
{
    public class GetDataService
    {
        private readonly DBRepository _dBRepository;
        public GetDataService(DBRepository dBRepository)
        {
            _dBRepository = dBRepository;
        }
        //房間總數
        public int RoomCount()
        {
            return _dBRepository.GetAll<Room>().Count();
        }

        public int UserCount()
        {
            return _dBRepository.GetAll<User>().Where(user => user.IsDelete != true).Count();
        }

        public int GetLastmonthIncome()
        {
            if (_dBRepository.GetAll<Order>().Where(order=> DateTime.Now.AddMonths(-1).Month == order.BookingDateTime.Month).Count() != 0)
            {
                return (int)_dBRepository.GetAll<Order>().Where(order => order.Status == 1 && DateTime.Now.AddMonths(-1).Month == order.BookingDateTime.Month).Sum(order => order.OriginalPrice);
            }
            else return 0;
        }
        public int GetThismonthIncome()
        {
            if (_dBRepository.GetAll<Order>().Where(order => DateTime.Now.Month == order.BookingDateTime.Month).Count() != 0)
            {
                return (int)_dBRepository.GetAll<Order>().Where(order => order.Status == 1 && DateTime.Now.Month == order.BookingDateTime.Month).Sum(order => order.OriginalPrice);
            }
            else return 0;
        }
    }
}
