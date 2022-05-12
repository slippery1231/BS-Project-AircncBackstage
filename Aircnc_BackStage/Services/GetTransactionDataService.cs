using Aircnc_BackStage.Models;
using Aircnc_BackStage.Models.Dtos;
using AircncFrontStage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aircnc_BackStage.Services
{
    public class GetTransactionDataService
    {
        private readonly DBRepository _dbRepository;
        public GetTransactionDataService(DBRepository dBRepository)
        {
            _dbRepository = dBRepository;
        }

        public IEnumerable<TransactionDto> GetAllTransactionData()
        {
            return _dbRepository.GetAll<TransactionStatus>().Select(x => new TransactionDto
            {
                TransactionStatusId = x.TransactionStatusId, //資料庫的流水編號
                UserId = x.UserId, //房東id
                Name = _dbRepository.GetAll<User>().FirstOrDefault(u=>u.UserId == x.UserId).Name,
                CreateTime = x.CreateTime.ToString("yyyy/MM/dd HH:mm:ss"),
                TotalAmount = x.TotalAmount,
                StatusType = x.StatusType == 1? "尚未撥款" : "已完成撥款",
                CheckIn = _dbRepository.GetAll<Order>().FirstOrDefault(o=>o.CkeckIn == x.Order.CkeckIn).CkeckIn.ToString(),
                CheckOut = _dbRepository.GetAll<Order>().FirstOrDefault(o=>o.CkeckOut == x.Order.CkeckOut).CkeckOut.ToString()

            });
        }

        public void UpdateTransaction(int transactionStatusId)
        {
            var target = _dbRepository.GetEntityById<TransactionStatus>(transactionStatusId);
            target.StatusType = 2;
            _dbRepository.Update<TransactionStatus>(target);
            _dbRepository.Save();
        }
    }
}    // Pending = 還在系統中, TransferredToOwner = 已轉帳給房東, ReturnedToGuest = 已退款給旅客

