using ElPalacio.Domain.Filters;
using ElPalacio.Domain.Helpers;
using ElPalacio.Domain.IConverter;
using ElPalacio.Domain.IManager;
using ElPalacio.Domain.IRepository;
using ElPalacio.Domain.Utils;

namespace ElPalacio.Domain.Manager
{
    public class BaseManager<TEntity, RViewModel, UViewModel> : IBaseManager<TEntity, RViewModel, UViewModel> where TEntity : class where RViewModel : class where UViewModel : class
    {

        private readonly IBaseRepository<TEntity> _repository;
        private readonly IConverter<TEntity, RViewModel, UViewModel> _converter;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseManager{TEntity, UViewModel}"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public BaseManager(IConverter<TEntity, RViewModel, UViewModel> converter, IBaseRepository<TEntity> repository)
        {
            _converter = converter;
            _repository = repository;
        }
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public virtual Tuple<List<UViewModel>, PagedResult<TEntity>> Get(QueryParameter pagingParameter, IFilter filter)
        {
            var source = _repository.Get().GetPaged(pagingParameter, filter);
            var resources = _converter.ConvertList(source.Results);

            source.Results = null;
            return new Tuple<List<UViewModel>, PagedResult<TEntity>>(resources, source);
        }
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual async Task<UViewModel> GetById(int id)
        {
            var entity = await _repository.GetById(id);

            return _converter.Convert(entity);
        }
        /// <summary>
        /// Posts the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public virtual async Task<UViewModel> Post(RViewModel model)
        {
            var entity = _converter.PrepareAddData(model);

            return _converter.Convert(await _repository.Post(entity));
        }
        /// <summary>
        /// Patches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        public virtual async Task Patch(int id, RViewModel model)
        {
            var entity = await _repository.GetById(id);

            var updatedEntity = _converter.PrepareUpdateData(entity, model);

            await _repository.Patch(updatedEntity);
        }
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public virtual async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}