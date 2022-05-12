using Aircnc_BackStage.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aircnc_BackStage.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GetRoomController : ControllerBase
    {
        private readonly GetRoomService _roomService;

        public GetRoomController(GetRoomService roomService)
        {
            _roomService = roomService;
        }

        public IActionResult GetAllRoomData()
        {
            var result = _roomService.GetAllRoom();

            return new JsonResult(result);
        }

        [HttpPost]
        public IActionResult UpdateRoomStatus([FromBody] int roomId)
        {
             _roomService.UpdateRoom(roomId);

            return new JsonResult("下架成功");
        }
    }
}
