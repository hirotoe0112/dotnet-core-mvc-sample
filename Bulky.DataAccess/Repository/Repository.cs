using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.DataAccess.Data;

namespace Bulky.DataAccess.Repository
{
  public class Repository<T> : IRepository<T> where T : class
  {
    private readonly ApplicationDbContext _db;
    internal DbSet<T> dbSet;

    public Repository(ApplicationDbContext db)
    {
      _db = db;
      dbSet = _db.Set<T>();
      // _db.Categories = dbSet;という意味
    }

    public IEnumerable<T> GetAll()
    {
      IQueryable<T> query = dbSet;
      return query.ToList();
    }

    public T? Get(Expression<Func<T, bool>> filter)
    {
      IQueryable<T> query = dbSet;
      return query.Where(filter).FirstOrDefault();
    }

    public void Add(T entity)
    {
      dbSet.Add(entity);
    }

    public void Remove(T entity)
    {
      dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
      dbSet.RemoveRange(entities);
    }
  }
}