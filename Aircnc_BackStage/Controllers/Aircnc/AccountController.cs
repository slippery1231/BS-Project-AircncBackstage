using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aircnc_BackStage.Controllers.Aircnc
{
    public class AccountController : Controller
    {

        public IActionResult Home()
        {

            return View();
        }

        public IActionResult Login()
        {

            return View();
        }
    }
}
