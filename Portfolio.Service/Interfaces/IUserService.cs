using Portfolio.Domain.Entities;
using Portfolio.Service.DTOs.Payment;
using Portfolio.Service.DTOs.User;

namespace PortfolioManagment.Services.Interfaces;

public interface IUserService
{
    Task<UserResultDto> AddAsync(UserCreationDto dto);
    Task<UserResultDto> ModifyAsync(UserUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<IEnumerable<UserResultDto>> GetAllAsync();
    Task<UserResultDto> GetAsync(long id);
    Task<PaymentResultDto> SentMoney(PaymentCreationDto dto);
}
