using Aircnc_BackStage.Models;
using Aircnc_BackStage.Models.Dtos;
using AircncFrontStage.Repositories;
using Microsoft.AspNetCore.Mvc;
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
                Birthday = x.Birthday == null? "未填寫" : x.Birthday.ToString(),
                Gender = x.Gender == false? "女性":"男性",
                EmergencyContactName = x.EmergencyContactName == null? "未填寫":x.EmergencyContactName,
                EmergencyContactPhone = x.EmergencyContactPhone == null ? "未填寫" : x.EmergencyContactPhone,
                CreateTime = x.CreateTime.ToString("yyyy/MM/dd HH:mm:ss"),
                IsDelete  = x.IsDelete == true? "已停用帳號":"帳號使用中",
                MailIsVerify = x.MailIsVerify ==true? "已驗證":"未驗證"
            });
        }

        [HttpPost]
        public void UpdateAccountStatus(int userId)
        {
            var toBeUpdate = _dBRepository.GetEntityById<User>(userId);
            toBeUpdate.IsDelete = true;
            _dBRepository.Update<User>(toBeUpdate);
            _dBRepository.Save();
        }
    }
}
