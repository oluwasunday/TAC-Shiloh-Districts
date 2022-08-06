using System.Linq.Expressions;

namespace TACShilohDistricts.Core.IRepositories.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity Get(int id);

        /// <summary>
        /// Gets all entities
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Gets entity as queryable
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAllAsQueryable();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Gets all entries that match specified conditions
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includeProperties">Additional entity properties to pull. Separate multiple entities with comma (,)</param>
        /// <returns></returns>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, string[] includeProperties);

        /// <summary>
        /// Gets all entries that match specified conditions asynchronously
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includeProperties">Additional entity properties to pull. Separate multiple entities with comma (,)</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, string[] includeProperties);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Gets entity from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(int id);

        /// <summary>
        /// Gets entity with criteria
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Gets all entries for this entity
        /// </summary>
        /// <param name="includeProperties">Specify additional properties to be pulled. Separate multiple properties by comma (,)</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll(string[] includeProperties);

        /// <summary>
        /// Gets requested entity
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includeProperties">Additional entity properties to pull. Separate multiple entities with comma (,) </param>
        /// <returns></returns>
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, string[] includeProperties);

        /// <summary>
        /// Confirms entity availability
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Add single entity to database
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);

        /// <summary>
        /// Adds range of entities to database
        /// </summary>
        /// <param name="entities"></param>
        void AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Removes entity from database
        /// </summary>
        /// <param name="entity"></param>
        void Remove(TEntity entity);

        /// <summary>
        /// Removes range of entities from database
        /// </summary>
        /// <param name="entities"></param>
        void RemoveRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Finds entity with an expression or func
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, string includeProperties = "");
    }
}
