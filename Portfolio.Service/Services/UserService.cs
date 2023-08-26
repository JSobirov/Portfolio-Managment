﻿using AutoMapper;
using Portfolio.Domain.Entities;
using Portfolio.Service.DTOs.User;
using Portfolio.DAL.IRepositoryes;
using Portfolio.Service.Exceptions;
using Portfolio.Service.DTOs.Payment;
using PortfolioManagment.Services.Interfaces;

namespace PortfolioManagment.Services.Services;

public class UserService : IUserService
{
    private readonly IMapper mapper;
    private readonly IRepository<User> repository;
    public UserService(IRepository<User> repository, IMapper mapper)
    {
        this.mapper = mapper;
        this.repository = repository;
    }

    public async Task<UserResultDto> AddAsync(UserCreationDto dto)
    {
        User existUser = await this.repository.SelectAsync(u => u.Email.Equals(dto.Email));
        if (existUser is not null)
            throw new AlreadyExistException($"This user is already exists with phone = {dto.Email}");

        var mappedUser = this.mapper.Map<User>(dto);
        await this.repository.CreateAsync(mappedUser);
        await this.repository.SaveAsync();

        var result = this.mapper.Map<UserResultDto>(mappedUser);
        return result;
    }

    public async Task<IEnumerable<UserResultDto>> GetAllAsync()
    {
        var users = this.repository.SelectAll();

        var result = this.mapper.Map<IEnumerable<UserResultDto>>(users);
        return result;
    }

    public async Task<UserResultDto> GetAsync(long id)
    {
        User existUser = await this.repository.SelectAsync(u => u.Id.Equals(id));
        if (existUser is null)
            throw new NotFoundException($"This user is not found with ID = {id}");

        var result = this.mapper.Map<UserResultDto>(existUser);
        return result;
    }

    public async Task<UserResultDto> ModifyAsync(UserUpdateDto dto)
    {
        User existUser = await this.repository.SelectAsync(u => u.Id.Equals(dto.Id));
        if (existUser is null)
            throw new NotFoundException($"This user is not found with ID = {dto.Id}");

        this.mapper.Map(dto, existUser);
        this.repository.Update(existUser);
        await this.repository.SaveAsync();

        var result = this.mapper.Map<UserResultDto>(existUser);
        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        User existUser = await this.repository.SelectAsync(u => u.Id.Equals(id));
        if (existUser is null)
            throw new NotFoundException($"This user is not found with ID = {id}");

        this.repository.Delete(existUser);
        await this.repository.SaveAsync();
        return true;
    }

    public async Task<PaymentResultDto> SentMoney(PaymentCreationDto dto)
    {
        var existTo = repository.SelectAll().FirstOrDefault(i => i.CardNumd.Equals(dto.ToCard));
        if (existTo is null)
            throw new NotFoundException($"Not Found User with {dto.ToCard} card Number");

        var existFrom = repository.SelectAll().FirstOrDefault(i => i.CardNumd.Equals(dto.FromCard));
        if (existFrom is null)
            throw new NotFoundException($"Not Found User with {dto.FromCard} card Number");

        if (existFrom.Money >= dto.Sum)
        {
            existTo.Money += dto.Sum;
            existFrom.Money -= dto.Sum;
            await repository.SaveAsync();
        }
        else
        {
            throw new NotFoundException("You haven't enough money");
        }

        var result = mapper.Map<PaymentResultDto>(dto);
        return result;
    }
}
