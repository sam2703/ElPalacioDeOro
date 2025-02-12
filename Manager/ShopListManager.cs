using ElPalacio.Domain.Entities;
using ElPalacio.Domain.IConverter;
using ElPalacio.Domain.IManager;
using ElPalacio.Domain.IRepository;
using ElPalacio.Domain.ViewModel;
using ElPalacio.Domain.ViewModel.Requests;

namespace ElPalacio.Domain.Manager
{
    public class ShopListManager : BaseManager<ShopList, ShopListRequestViewModel, ShopListViewModel>, IShopListManager
    {
        private readonly IShopListRepository _repository;
        private readonly IShopListConverter _converter;

        public ShopListManager(IShopListConverter converter, IShopListRepository repository) : base(converter, repository)
        {
            _converter = converter;
            _repository = repository;
        }
    }
}