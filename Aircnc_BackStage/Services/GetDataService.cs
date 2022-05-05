using Aircnc_BackStage.Models;
using Aircnc_BackStage.Models.DataModels;
using Aircnc_BackStage.Repositories.Interface;
using Aircnc_BackStage.Repositories.Redis;
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
        private readonly IMemoryCacheRepository _memoryCacheRepository;
        public GetDataService(DBRepository dBRepository, IMemoryCacheRepository memoryCacheRepository)
        {
            _dBRepository = dBRepository;
            _memoryCacheRepository = memoryCacheRepository;
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
        public int GetTodayIncome()
        {
            if (_dBRepository.GetAll<Order>().Where(order => DateTime.UtcNow.AddHours(8).Date == order.BookingDateTime.Date).Count() != 0)
            {
                return (int)_dBRepository.GetAll<Order>().Where(order => DateTime.UtcNow.AddHours(8).Date == order.BookingDateTime.Date).Sum(order => order.OriginalPrice);
            }
            else return 0;
        }
        public int GetLastmonthIncome()
        {
            if (_dBRepository.GetAll<Order>().Where(order=> DateTime.UtcNow.AddHours(8).AddMonths(-1).Month == order.BookingDateTime.Month).Count() != 0)
            {
                return (int)_dBRepository.GetAll<Order>().Where(order =>  DateTime.Now.AddMonths(-1).Month == order.BookingDateTime.Month).Sum(order => order.OriginalPrice);
            }
            else return 0;
        }
        //1
        public int GetThismonthIncome()
        {
            if (_dBRepository.GetAll<Order>().Where(order => DateTime.UtcNow.AddHours(8).Month == order.BookingDateTime.Month).Count() != 0)
            {
                return (int)_dBRepository.GetAll<Order>().Where(order => DateTime.Now.Month == order.BookingDateTime.Month).Sum(order => order.OriginalPrice);
            }
            else return 0;
        }
        public int GetThisMonthRoom()
        {
            var result = _dBRepository.GetAll<Room>().Where(x => x.CreateTime.Month == DateTime.UtcNow.AddHours(8).Month).Count() == 0 ?
                0 : _dBRepository.GetAll<Room>().Where(x => x.CreateTime.Month == DateTime.UtcNow.AddHours(8).Month).Count();

            return result;
        }
        public int GetThisMonthUser()
        {
            var result = _dBRepository.GetAll<User>().Where(x => x.CreateTime.Month == DateTime.UtcNow.AddHours(8).Month).Count() == 0 ?
                0 : _dBRepository.GetAll<User>().Where(x => x.CreateTime.Month == DateTime.UtcNow.AddHours(8).Month).Count();

            return result;
        }
        public int GetTodayRoom()
        {
            var result = _dBRepository.GetAll<Room>().Where(x => x.CreateTime.Date == DateTime.UtcNow.AddHours(8).Date).Count() == 0 ?
                0 : _dBRepository.GetAll<Room>().Where(x => x.CreateTime.Date == DateTime.UtcNow.AddHours(8).Date).Count();

            return result;
        }
        public int GetTodayUser()
        {
            var result = _dBRepository.GetAll<User>().Where(x => x.CreateTime.Date == DateTime.UtcNow.AddHours(8).Date).Count() == 0 ?
                0 : _dBRepository.GetAll<User>().Where(x => x.CreateTime.Date == DateTime.UtcNow.AddHours(8).Date).Count();

            return result;
        }

        public IEnumerable<ChartDataModel> GetChartData()
        {
            var result = _memoryCacheRepository.Get<IEnumerable<ChartDataModel>>("Aircnc.ChartData");
            if (result != null) return result;

             result =  _dBRepository.GetAll<Room>().ToArray().GroupBy(x => x.City)
               .Select(x => new
               {
                   City = x.Key,
                   RoomCount = x.Count(),
               })
               .OrderByDescending(x => x.RoomCount).Take(10)
               .Select((x, index) => new ChartDataModel
                {
                    Ranking = index + 1,
                    Area = x.City,
                    Ratio = x.RoomCount / (float)(_dBRepository.GetAll<Room>().Count())
                });

            _memoryCacheRepository.Set<IEnumerable<ChartDataModel>>("Aircnc.ChartData",result);
            return result;
        }
        public IEnumerable<PieDataModel> GetPieData()
        {
            var result = _memoryCacheRepository.Get<IEnumerable<PieDataModel>>("Aircnc.PieData");
            if (result != null) return result;
            result = _dBRepository.GetAll<Order>().ToArray().GroupBy(x => x.City)
               .Select(x => new
               {
                   City = x.Key,
                   Total = x.Sum(y=>y.OriginalPrice),
               })
               .OrderByDescending(x => x.Total).Take(5)
                .Select((x, index) => new PieDataModel
                {
                    Ranking = index + 1,
                    Area = x.City,
                    Ratio = (float)x.Total / (float)(_dBRepository.GetAll<Order>().Sum(y=>y.OriginalPrice))
                });
            _memoryCacheRepository.Set<IEnumerable<PieDataModel>>("Aircnc.PieData",result);
            return result;
        }

    }
}
