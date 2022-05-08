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
    public class GetUserDataController : ControllerBase
    {
        private readonly GetUserService _getUserService;
        public GetUserDataController(GetUserService getUserService)
        {
            _getUserService = getUserService;
        }

        [HttpGet]
        public IActionResult GetUsersData()
        {
            var result = _getUserService.GetUsersData();

            return new JsonResult(result);
        }

        [HttpGet]
        public IActionResult UpdateAccountStatus(int userId)
        {
              _getUserService.UpdateAccountStatus(userId);
            return new JsonResult("停用成功");
        }
    }
}
