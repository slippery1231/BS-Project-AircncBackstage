using Aircnc_BackStage.Models.ViewModels;
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
        [Authorize]
        
        public IActionResult GetHomePageData()
        {
            var result = new HomePageViewModel
            {
                RoomCount = _getDataService.RoomCount(),
                UserCount = _getDataService.UserCount(),
                LastMonthIncome = _getDataService.GetLastmonthIncome(),
                ThisMonthIncome = _getDataService.GetThismonthIncome(),
                
            };
            return new JsonResult(result);
        }
        public IActionResult GetCharData()
        {
            var result = _getDataService.GetChartData();

            return new JsonResult(result);
        }

    }
}
