using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Bulky.Models;

namespace Bulky.DataAccess.Repository.IRepository
{
  public interface ICategoryRepository : IRepository<Category>
  {
    IEnumerable<Category> GetAll();
    Category Get(Expression<Func<Category, bool>> filter);
    void Add(Category entity);
    void Update(Category entity);
    void Remove(Category entity);
    void RemoveRange(IEnumerable<Category> entities);
    void Save();
  }
}
