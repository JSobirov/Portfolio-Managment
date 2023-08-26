using Portfolio.DAL.IRepositoryes;
using Portfolio.DAL.Repositories;
using Portfolio.Service.Mappers;
using PortfolioManagment.Services.Interfaces;
using PortfolioManagment.Services.Services;

namespace PortfolioManagment.Extensions;

public static class ServiceColection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPaymentService, PaymentService>();
    }
}   
