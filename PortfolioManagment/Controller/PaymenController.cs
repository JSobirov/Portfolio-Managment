using Recore.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using PortfolioManagment.Services.Interfaces;

namespace PortfolioManagment.Controller
{
    [ApiController]
    [Route("[controller]")]

    public class PaymenController : ControllerBase
    {
        private readonly IPaymentService paymentService;
        public PaymenController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        [HttpGet("get")]
        public async ValueTask<IActionResult> GetByCardNumberAsync(string cardNumb)
            => Ok(new Response
           {
               StatusCode = 200,
               Message = "Success",
               Data = await this.paymentService.GetByCardNumberAsync(cardNumb)
           });


        [HttpGet("get-all")]
        public async ValueTask<IActionResult> GetAllAsync()
            => Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.paymentService.GetAllAsync()
            });
    }
}
