﻿using Portfolio.Domain.Commons;
using System.Linq.Expressions;

namespace Portfolio.DAL.IRepositoryes;

public interface IRepository<T> where T : Auditable
{
    Task CreateAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<T> SelectAsync(Expression<Func<T, bool>> expression, string[] includes = null);
    IQueryable<T> SelectAll(Expression<Func<T, bool>> expression = null, bool isNoTracked = true, string[] includes = null);
    Task SaveAsync();
}
