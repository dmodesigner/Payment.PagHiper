using Domain.Interfaces.Services;
using Domain.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("v1/bank-slip")]
    [ApiController]
    public class BankSlipController : ControllerBase
    {
        private readonly IBankSlipService _bankSlipService;

        public BankSlipController(IBankSlipService bankSlipService) => _bankSlipService = bankSlipService;

        [HttpPost, Route("create")]
        public IActionResult CreateBankSlip(BankSlipRequest request)
        {
            try
            {
                 return Ok(_bankSlipService.CreateBankSlip(request));
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
