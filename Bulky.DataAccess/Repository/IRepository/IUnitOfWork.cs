using Bulky.DataAccess.Repository.IRepository;

namespace Bulky.DataAccess.Repository.IRepository
{
  public interface IUnitOfWork
  {
    ICategoryRepository CategoryRepository { get; }

    void Save();
  }
}