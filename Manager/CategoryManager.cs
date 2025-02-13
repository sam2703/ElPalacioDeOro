using ElPalacio.Domain.Entities;
using ElPalacio.Domain.IConverter;
using ElPalacio.Domain.IManager;
using ElPalacio.Domain.IRepository;
using ElPalacio.Domain.ViewModel;
using ElPalacio.Domain.ViewModel.Requests;

namespace ElPalacio.Domain.Manager
{
    public class CategoryManager : BaseManager<Category, CategoryRequestViewModel, CategoryViewModel>, ICategoryManager
    {
        private readonly ICategoryRepository _repository;
        private readonly ICategoryConverter _converter;
        public CategoryManager(ICategoryConverter converter, ICategoryRepository repository) : base(converter, repository)
        {
            _converter = converter;
            _repository = repository;
        }
    }
}