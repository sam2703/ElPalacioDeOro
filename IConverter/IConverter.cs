namespace ElPalacio.Domain.IConverter
{
    public interface IConverter<TEntity, RViewModel, UViewModel> where TEntity : class where RViewModel : class where UViewModel : class
    {

        TEntity PrepareAddData(RViewModel viewModel);
        TEntity PrepareUpdateData(TEntity entity, RViewModel viewModel);
        /// <summary>
        /// Converts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        UViewModel Convert(TEntity entity);
        /// <summary>
        /// Converts the list.
        /// </summary>
        /// <param name="entityList">The entity list.</param>
        /// <returns></returns>
        List<UViewModel> ConvertList(IEnumerable<TEntity> entityList);
    }
}