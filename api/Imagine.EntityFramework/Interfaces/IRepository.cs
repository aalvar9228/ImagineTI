using Imagine.EntityFramework.Entities;
using System.Linq.Expressions;

namespace Imagine.EntityFramework.Interfaces
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        IEnumerable<TEntity> Filter(
            int page = 1,
            int pageSize = -1,
            Expression<Func<TEntity, bool>>? filter = null);
    }
}
