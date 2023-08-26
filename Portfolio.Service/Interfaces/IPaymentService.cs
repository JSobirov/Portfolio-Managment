using Portfolio.Domain.Entities;
using Portfolio.Service.DTOs.Payment;

namespace PortfolioManagment.Services.Interfaces;

public interface IPaymentService
{
    Task<IEnumerable<Payment>> GetAllAsync(); 
}
