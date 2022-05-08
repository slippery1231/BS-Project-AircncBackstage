using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aircnc_BackStage.Controllers.Aircnc
{
    public class TransactionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TransactionData()
        {
            return View();
        }
    }
}
