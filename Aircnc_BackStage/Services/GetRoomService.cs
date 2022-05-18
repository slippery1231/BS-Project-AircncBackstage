using Aircnc_BackStage.Models;
using Aircnc_BackStage.Models.Dtos;
using AircncFrontStage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aircnc_BackStage.Services
{
    public class GetRoomService
    {
        private readonly DBRepository _dbRepository;
        public GetRoomService(DBRepository dBRepository)
        {
            _dbRepository = dBRepository;
        }

        public IEnumerable<RoomDto> GetAllRoom()
        {
            return _dbRepository.GetAll<Room>().OrderByDescending(x=>x.CreateTime).Select(x => new RoomDto
            {
                RoomId = x.RoomId,
                UserName = _dbRepository.GetAll<User>().FirstOrDefault(u=>u.UserId ==x.User.UserId).Name,
                Address = $"{x.City} {x.District}",
                RoomName = x.RoomName,
                UnitPrice = x.UnitPrice,
                CreateTime = x.CreateTime.ToString("yyyy/MM/dd HH:mm:ss"),
                Status = x.Status==1? "已上架" : "已下架"
            });
        }

        public void UpdateRoom(int roomId)
        {
            var toBeUpdate = _dbRepository.GetEntityById<Room>(roomId);
            toBeUpdate.Status = 2;
            _dbRepository.Update<Room>(toBeUpdate);
            _dbRepository.Save();
        }
    }
}
