using Aircnc_BackStage.Helpers;
using Aircnc_BackStage.Models.ViewModels;
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
    public class APILoginController : ControllerBase
    {


        private readonly JwtHelper _jwtHelper;
        public APILoginController()
        {
            _jwtHelper = new JwtHelper();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel userdata)
        {
            if (userdata.Username == "admin" && userdata.Password == "ADMIN")
            {
                return Ok(_jwtHelper.GenerateToken(userdata.Username));
            }
            else
            {
                //throw new Exception("登入失敗，帳號或密碼錯誤");
                return null;
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult Test()
        {
          
                return Ok("通過");
           
        }

    }
}
