using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TACShilohDistricts.Core.IRepositories.Base;
using TACShilohDistricts.Infrastructure.Data;

namespace TACShilohDistricts.Infrastructure.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly TACShilohContext _context;
        private readonly DbSet<TEntity> _dbSet;


        public Repository(TACShilohContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public TEntity Get(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, string[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (includeProperties.Length > 0)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query.Include(includeProperty);
                }
            }
            return query.FirstOrDefaultAsync(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> GetAllAsQueryable()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public IEnumerable<TEntity> GetAll(string[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (includeProperties.Length > 0)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query.Include(includeProperty);
                }
            }
            return query.ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, string[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (includeProperties.Length > 0)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query.Include(includeProperty);
                }
            }
            return query.Where(predicate);
        }

        public Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, string includeProperties = "")
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            query = _IncludeProperties(query, includeProperties);
            return Task.FromResult<IEnumerable<TEntity>>(query.Where(predicate).ToList());
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().AnyAsync(predicate);
        }

        public Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, string[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return Task.FromResult<IEnumerable<TEntity>>(query.Where(predicate).ToList());
        }

        private IQueryable<TEntity> _IncludeProperties(IQueryable<TEntity> query, string properties)
        {
            if (!string.IsNullOrEmpty(properties))
            {
                foreach (var property in properties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property.Trim());
                }
            }
            return query;
        }
    }
}
