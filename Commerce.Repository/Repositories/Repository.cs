using AutoMapper;
using Commerce.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IMapper _mapper;

        protected readonly CommerceContext DbContext;

        public Repository(CommerceContext dbContext,  IMapper mapper)
        {
            _mapper = mapper;
            DbContext = dbContext;
        }

        public IEnumerable<T> Get()
        {
            return DbContext.Set<T>().AsEnumerable();
        }

        public Task<List<T>> GetAsync(CommerceContext db = null)
        {
            db ??= DbContext;
            return db.Set<T>().AsNoTracking().ToListAsync();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().Where(predicate).AsEnumerable();
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().FirstOrDefaultAsync(predicate);

        }

        public Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate, CommerceContext db = null)
        {
            db ??= DbContext;
            return db.Set<T>().Where(predicate).ToListAsync();
        }

        public T Find(int id, CommerceContext db = null)
        {
            db ??= DbContext;
            return db.Set<T>().Find(id);
        }

        public ValueTask<T> FindAsync(int id, CommerceContext db = null)
        {
            db ??= DbContext;
            return db.Set<T>().FindAsync(id);
        }

        public void Add(T entity, CommerceContext db = null)
        {
            db ??= DbContext;
            db.Set<T>().AddAsync(entity);
            db.SaveChanges(); 
        }

        public void AddRange(IEnumerable<T> entities)
        {
            DbContext.Set<T>().AddRangeAsync(entities);
            DbContext.SaveChanges();
        }

        public void Delete(T entity, CommerceContext db = null)
        {
            db ??= DbContext;
            db.Set<T>().Remove(entity);
            db.SaveChanges(); // Save this because it can related on foreign keys
        }

        public void DeleteRange(IEnumerable<T> entities, CommerceContext db = null)
        {
            db ??= DbContext;
            db.Set<T>().RemoveRange(entities);
            db.SaveChanges(); 
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            DbContext.Set<T>().UpdateRange(entities);
            DbContext.SaveChanges();
        }

        public void Update(T entity, CommerceContext db = null)
        {
            db ??= DbContext;
            db.Entry(entity).State = EntityState.Modified;
            DbContext.SaveChanges();
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().AnyAsync(predicate);
        }
    }
}
