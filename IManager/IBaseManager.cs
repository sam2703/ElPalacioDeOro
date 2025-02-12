using ElPalacio.Domain.Filters;
using ElPalacio.Domain.Utils;

namespace ElPalacio.Domain.IManager
{
    public interface IBaseManager<TEntity, RViewModel, UViewModel> where TEntity : class where RViewModel : class where UViewModel : class
    {
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        Tuple<List<UViewModel>, PagedResult<TEntity>> Get(QueryParameter pagingParameter, IFilter filter);
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<UViewModel> GetById(int id);
        /// <summary>
        /// Posts the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task<UViewModel> Post(RViewModel model);
        /// <summary>
        /// Patches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task Patch(int id, RViewModel model);
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        Task Delete(int id);
    }
}