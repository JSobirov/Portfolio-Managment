/*using AutoMapper;
using Portfolio.DAL.IRepositoryes;
using Portfolio.Domain.Entities;
using Portfolio.Service.DTOs.Payment;
using Portfolio.Service.DTOs.User;
using PortfolioManagment.Services.Interfaces;

namespace PortfolioManagment.Services.Services;

public class PaymentService : IPaymentService
{
    private readonly IMapper mapper;
    private readonly IRepository<Payment> repository;
    public PaymentService(IRepository<Payment> repository, IMapper mapper)
    {

        this.mapper = mapper;
        this.repository = repository;
    }

    public Task<IEnumerable<PaymentResultDto>> GetAllAsync()
    {
        var payments = this.repository.SelectAll();

        var result = this.mapper.Map<IEnumerable<PaymentResultDto>>(payments);
        return res;
    }*/
//}