using AutoMapper;
using Portfolio.Domain.Entities;
using Portfolio.Service.DTOs.Payment;
using Portfolio.Service.DTOs.User;

namespace Portfolio.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //User
        CreateMap<User, UserResultDto>().ReverseMap();
        CreateMap<UserCreationDto, User>().ReverseMap();
        CreateMap<UserUpdateDto, User>().ReverseMap();

        //Payment
        CreateMap<Payment, PaymentResultDto>().ReverseMap();
        CreateMap<PaymentResultDto, Payment>().ReverseMap();
    }
}
