using Microsoft.EntityFrameworkCore;
using Portfolio.DAL.Contexts;
using Portfolio.DAL.IRepositoryes;
using Portfolio.Domain.Commons;
using System.Linq.Expressions;

namespace Portfolio.DAL.Repositories;

public class Repository<T> : IRepository<T> where T : Auditable
{
    private readonly AppDbContext appDbContext;
    private readonly DbSet<T> dbSet;
    public Repository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
        dbSet = appDbContext.Set<T>();
    }

    public async Task CreateAsync(T entity)
    {
        await dbSet.AddAsync(entity);
    }

    public void Delete(T entity)
    {
        entity.IsDeleted = true;
    }

    public async Task SaveAsync()
    {
        appDbContext.SaveChangesAsync();
    }

    public IQueryable<T> SelectAll(Expression<Func<T, bool>> expression = null, bool isNoTracked = true, string[] includes = null)
    {
        IQueryable<T> query = expression is null ? dbSet.AsQueryable() : dbSet.Where(expression).AsQueryable();

        query = isNoTracked ? query.AsNoTracking() : query;

        if (includes is not null)
            foreach (var include in includes)
                query = query.Include(include);

        return query;
    }

    public async Task<T> SelectAsync(Expression<Func<T, bool>> expression, string[] includes = null)
    {
        IQueryable<T> query = dbSet.Where(expression).AsQueryable();

        if (includes is not null)
            foreach (var include in includes)
                query = query.Include(include);

        var entity = await query.FirstOrDefaultAsync(expression);
        return entity;
    }

    public void Update(T entity)
    {
        entity.UpdateAt = DateTime.UtcNow;
        appDbContext.Entry(entity).State = EntityState.Modified;
    }
}
