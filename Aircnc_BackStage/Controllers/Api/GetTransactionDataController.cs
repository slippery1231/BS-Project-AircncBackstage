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
    public class GetTransactionDataController : ControllerBase
    {
        private readonly GetTransactionDataService _getData;
        public GetTransactionDataController(GetTransactionDataService getData)
        {
            _getData = getData;
        }

        [HttpGet]
        public IActionResult GetAllTransactionData()
        {
            var result = _getData.GetAllTransactionData();

            return new JsonResult(result);
        }

        [HttpPost]
        public IActionResult UpdateTransactionStatus([FromBody]int transactionStatusId)
        {
             _getData.UpdateTransaction(transactionStatusId);
            return new JsonResult("撥款成功");
        }
    }
}
