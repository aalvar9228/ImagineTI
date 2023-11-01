using Imagine.EntityFramework.Entities;
using Imagine.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Imagine.EntityFramework.Repositories
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        private readonly ApplicationContext Context;
        private readonly DbSet<TEntity> DbSet;

        public EFRepository(ApplicationContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Filter(int page = 1, int pageSize = -1, Expression<Func<TEntity, bool>>? filter = null)
        {
            try
            {
                IQueryable<TEntity> query = DbSet;
                if (filter != null)
                    query = query.Where(filter);

                var result = query.ToList();

                if (result?.Any() ?? false)
                {
                    if (pageSize == -1)
                        return result;

                    var skip = (page - 1) * pageSize;
                    return result.AsQueryable().Skip(skip).Take(pageSize);
                }

                return new List<TEntity>();
            }
            catch (Exception)
            {
                return new List<TEntity>();
            }
        }
    }
}
