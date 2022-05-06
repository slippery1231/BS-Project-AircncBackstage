using Aircnc_BackStage.Models;
using Aircnc_BackStage.Models.Dtos;
using AircncFrontStage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aircnc_BackStage.Services
{
    public class GetUserService
    {
        private readonly DBRepository _dBRepository;
        public GetUserService(DBRepository dBRepository)
        {
            _dBRepository = dBRepository;
        }

        public IEnumerable<UserDto> GetUsersData()
        {
            return _dBRepository.GetAll<User>().Select(x=>new UserDto {
                UserId = x.UserId,
                Name = x.Name,
                Email = x.Email,
                Phone = x.Phone == null ? "未填寫" : x.Phone,
                Address= x.Address == null? "未填寫": x.Address,
                //Password = x.Password,
                Birthday = x.Birthday == null? "未填寫" : x.Birthday.ToString(),
                Gender = x.Gender == false? "女性":"男性",
                //Photo = x.Photo,
                EmergencyContactName = x.EmergencyContactName == null? "未填寫":x.EmergencyContactName,
                EmergencyContactPhone = x.EmergencyContactPhone == null ? "未填寫" : x.EmergencyContactPhone,
                CreateTime = x.CreateTime.ToString("yyyy/MM/dd HH:mm:ss"),
                //UserVerificationId = x.UserVerificationId,
                //BankVerificationId = x.BankVerificationId,
                IsDelete  = x.IsDelete == true? "已刪除帳號":"帳號使用中",
                MailIsVerify = x.MailIsVerify ==true? "已驗證":"未驗證"
            });
        }
    }
}
