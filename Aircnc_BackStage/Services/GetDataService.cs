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

    }
}
