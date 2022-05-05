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
                Phone = x.Phone,
                Address= x.Address,
                Password = x.Password,
                Birthday = x.Birthday,
                Gender = x.Gender,
                Photo = x.Photo,
                EmergencyContactName = x.EmergencyContactName,
                EmergencyContactPhone = x.EmergencyContactPhone,
                CreateTime = x.CreateTime.ToString("yyyy/MM/dd HH:mm:ss"),
                UserVerificationId = x.UserVerificationId,
                BankVerificationId = x.BankVerificationId,
                IsDelete  = x.IsDelete,
                MailIsVerify = x.MailIsVerify
            });
        }
    }
}
