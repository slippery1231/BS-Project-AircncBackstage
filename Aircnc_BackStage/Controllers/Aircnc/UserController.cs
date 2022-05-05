using Aircnc_BackStage.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aircnc_BackStage.Controllers.Aircnc
{
    public class UserController : Controller
    {
        private readonly GetUserService _getUserService;
        public UserController(GetUserService getUserService)
        {
            _getUserService = getUserService;
        }

        public IActionResult GetUsersData()
        {
            var result = _getUserService.GetUsersData();

            return View(result);
        }



    }
}
