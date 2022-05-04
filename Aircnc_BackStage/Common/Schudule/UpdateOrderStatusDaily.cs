using Aircnc_BackStage.Models;
using AircncFrontStage.Repositories;
using Coravel.Invocable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aircnc_BackStage.Common.Schudule
{
    public class UpdateOrderStatusDaily : IInvocable
    {
        private readonly DBRepository _dBRepository;

        public UpdateOrderStatusDaily(DBRepository dBRepository)
        {
            _dBRepository = dBRepository;
            
        }

        //每天去更改一次
        public Task Invoke()
        {
            var orders = _dBRepository.GetAll<Order>().Where(order =>order.Status== 3 && order.CkeckIn < DateTime.UtcNow.AddHours(8).Date);
            foreach (var order in orders)
            {
                order.Status = 1;
                _dBRepository.Update<Order>(order);
            }
            _dBRepository.Save();
            return Task.CompletedTask;
        }

        //public enum OrderStatusEnum
        //{
        //    [Description("已完成")]
        //    Past = 1,
        //    [Description("已取消")]
        //    Cancel = 2,
        //    [Description("將至旅程")]
        //    Future = 3
        //}
    }
}

