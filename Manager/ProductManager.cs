using ElPalacio.Domain.Entities;
using ElPalacio.Domain.IConverter;
using ElPalacio.Domain.IManager;
using ElPalacio.Domain.IRepository;
using ElPalacio.Domain.ViewModel;
using ElPalacio.Domain.ViewModel.Requests;

namespace ElPalacio.Domain.Manager
{
    public class ProductManager : BaseManager<Product, ProductRequestViewModel, ProductViewModel>, IProductManager
    {
        private readonly IProductRepository _repository;
        private readonly IProductConverter _converter;

        public ProductManager(IProductConverter converter, IProductRepository repository) : base(converter, repository)
        {
            _converter = converter;
            _repository = repository;
        }
    }
}