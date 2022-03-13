using Commerce.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Repository.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
        Task<List<T>> GetAsync(CommerceContext db = null);
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate, CommerceContext db = null);
        T Find(int id, CommerceContext db = null);
        ValueTask<T> FindAsync(int id, CommerceContext db = null);
        void Add(T entity, CommerceContext db = null);
        void Delete(T entity, CommerceContext db = null);
        void DeleteRange(IEnumerable<T> entities, CommerceContext db = null);
        void Update(T entity, CommerceContext db = null);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        void UpdateRange(IEnumerable<T> entities);
        void AddRange(IEnumerable<T> entities);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    }
}
