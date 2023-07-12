using Ordering.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Contracts.Persistence
{
    /// <summary>
    /// Data access tools for entities of the data source.
    /// </summary>
    /// <typeparam name="T">Entity of hte data source.</typeparam>
    public interface IRepository<T> where T : EntityBase
    {
        /// <summary>
        /// Method for reading all entities from the data source.
        /// </summary>
        /// <returns>Collection of entities from the data source.</returns>
        Task<IReadOnlyList<T>> GetAll();

        /// <summary>
        /// Method for filtering all entities from the data source by passed predicate.
        /// </summary>
        /// <param name="predicate">Predicate to filter entities.</param>
        /// <returns>Collection of filtered entities from the data source.</returns>
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
        
        /// <summary>
        /// Mehtod for filtering and sorting all entities from the data source.
        /// </summary>
        /// <param name="predicate">Predicate to filter entities.</param>
        /// <param name="orderBy">Expression to sort entities.</param>
        /// <param name="includeString">String for inner join table of current entity with other tables.</param>
        /// <param name="disableTracking">Flag for enabling the tracking.</param>
        /// <returns>Collection of filtered entities from the data source.</returns>
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                        string? includeString = null,
                                        bool disableTracking = true);

        /// <summary>
        /// Mehtod for filtering and sorting all entities from the data source.
        /// </summary>
        /// <param name="predicate">Predicate to filter entities.</param>
        /// <param name="orderBy">Expression to sort entities.</param>
        /// <param name="includes">Expressions for inner joins between tables of the data source.</param>
        /// <param name="disableTracking">Flag for enabling the tracking.</param>
        /// <returns>Collection of filtered entities from the data source.</returns>
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                        List<Expression<Func<T, object>>>? includes = null,
                                        bool disableTracking = true);

        /// <summary>
        /// Method for reading entity from the data source by it`s Id.
        /// </summary>
        /// <param name="id">Guid of entity to read.</param>
        /// <returns>Entity with passed guid, null - if entity is not found.</returns>
        Task<T?> GetByIdAsync(Guid id);

        /// <summary>
        /// Method for adding new entity to the data source.
        /// </summary>
        /// <param name="entity">Entity to add.</param>
        /// <returns>Entity added to the data source.</returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Method for updating the entity in the data source.
        /// </summary>
        /// <param name="entity">Entity to update.</param>
        /// <returns>True - if entity is successfully updated, otherwise - false.</returns>
        Task<bool> UpdateAsync(T entity);

        /// <summary>
        /// Method for deleting the entity from the data source.
        /// </summary>
        /// <param name="id">Guid of entity to delete.</param>
        /// <returns>True - if entity is successfully deleted, otherwise - false.</returns>
        Task<bool> DeleteAsync(Guid id);
    }
}
