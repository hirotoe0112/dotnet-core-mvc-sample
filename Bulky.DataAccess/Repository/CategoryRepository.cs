using Bulky.DataAccess.Repository.IRepository;
using Bulky.DataAccess.Data;
using Bulky.Models;

namespace Bulky.DataAccess.Repository
{
  public class CategoryRepository : Repository<Category>, ICategoryRepository
  {
    private ApplicationDbContext _db;
    public CategoryRepository(ApplicationDbContext db) : base(db)
    {
      _db = db;
    }
    public void Update(Category entity)
    {
      _db.Categories.Update(entity);
    }
  }
}
