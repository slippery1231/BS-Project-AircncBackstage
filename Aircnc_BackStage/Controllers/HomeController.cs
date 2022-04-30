using Aircnc_BackStage.Models;
using AircncFrontStage.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Aircnc_BackStage.Controllers
{
    public class HomeController : Controller
    {
        private readonly DBRepository _dBRepository;

        public HomeController(DBRepository dBRepository)
        {
            _dBRepository = dBRepository;
        }
        public IActionResult r()
        {
            

            return View(_dBRepository.GetAll<User>());
        
        }
        
    }
}
