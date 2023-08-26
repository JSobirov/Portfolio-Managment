using Microsoft.AspNetCore.Mvc;
using Portfolio.Service.DTOs.Payment;
using Portfolio.Service.DTOs.User;
using PortfolioManagment.Services.Interfaces;
using Recore.WebApi.Models;

namespace PortfolioManagment.Controller
{
    [ApiController]
    [Route("[controller]")]

    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("create")]
        public async ValueTask<IActionResult> PostAsync(UserCreationDto dto)
    => Ok(new Response
    {
        StatusCode = 200,
        Message = "Success",
        Data = await this.userService.AddAsync(dto)
    });



        [HttpPut("update")]
        public async ValueTask<IActionResult> PutAsync(UserUpdateDto dto)
            => Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.userService.ModifyAsync(dto)
            });


        [HttpDelete("delete/{id:long}")]
        public async ValueTask<IActionResult> DeleteAsync(long id)
            => Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.userService.RemoveAsync(id)
            });


        [HttpGet("get/{id:long}")]
        public async ValueTask<IActionResult> GetByIdAsync(long id)
            => Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.userService.GetAsync(id)
            });


        [HttpGet("get-all")]
        public async ValueTask<IActionResult> GetAllAsync()
            => Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.userService.GetAllAsync()
            });

        [HttpPost("SendMoney")]
        public async ValueTask<IActionResult> SendMoneyAsync(PaymentCreationDto dto)
             => Ok(new Response
             {
                 StatusCode = 200,
                 Message = "Success",
                 Data = await this.userService.SentMoney(dto)
             });
    }
}