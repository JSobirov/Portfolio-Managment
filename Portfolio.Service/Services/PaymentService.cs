using AutoMapper;
using Portfolio.Domain.Entities;
using Portfolio.DAL.IRepositoryes;
using Microsoft.EntityFrameworkCore;
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

    public async Task<IEnumerable<Payment>> GetAllAsync()
    {
        var payments = repository.SelectAll();

        payments.Include(x => x.FromUser);
        payments.Include(i => i.toUser);

        return payments;
    }

    public async Task<IEnumerable<Payment>> GetByCardNumberAsync(string cardNumber)
    {
        var payments = repository.SelectAll().Where(a => a.FromCard.Equals(cardNumber));

        payments.Include(x => x.FromUser);
        payments.Include(i => i.toUser);

        return payments;
    }
}