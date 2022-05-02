using Aircnc_BackStage.Services;
using Microsoft.AspNetCore.Authorization;
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
    public class GetDataController : ControllerBase
    {
        private readonly GetDataService _getDataService;
        public GetDataController(GetDataService getDataService)
        {
            _getDataService = getDataService;


        }
        [HttpGet]
        
        public IActionResult GetAllRoomCount()
        {
            var result = _getDataService.RoomCount();

            return new JsonResult(result.ToString());
        }
    }
}
