using ElPalacio.Domain.Entities;
using ElPalacio.Domain.IConverter;
using ElPalacio.Domain.ViewModel;
using ElPalacio.Domain.ViewModel.Requests;

namespace ElPalacio.Domain.Converters
{
    public class ShopListConverter : IConverter<ShopList, ShopListRequestViewModel, ShopListViewModel>, IShopListConverter
    {

        public ShopListViewModel Convert(ShopList shopList)
        {
            var shopListViewModel = new ShopListViewModel
            {
                Id = shopList.Id,
                CheckoutFK = shopList.CheckoutFK,
                FreeDelivery = shopList.FreeDelivery,
                Active = shopList.Active,
                CreatedAt = shopList.CreatedAt,
                UpdatedAt = shopList.UpdatedAt
            };

            return shopListViewModel;
        }

        public List<ShopListViewModel> ConvertList(IEnumerable<ShopList> shopList)
        {
            return shopList.Select(b =>
            {
                var model = new ShopListViewModel
                {
                    Id = b.Id,
                    CheckoutFK = b.CheckoutFK,
                    FreeDelivery = b.FreeDelivery,
                    Active = b.Active,
                    CreatedAt = b.CreatedAt,
                    UpdatedAt = b.UpdatedAt
                };

                return model;
            }).ToList();
        }
        public ShopList PrepareAddData(ShopListRequestViewModel viewModel)
        {
            return new ShopList()
            {
                CheckoutFK = viewModel.CheckoutFK,
                FreeDelivery = viewModel.FreeDelivery,
                Active = viewModel.Active,
                CreatedAt = DateTime.Now,
            };
        }

        public ShopList PrepareUpdateData(ShopList entity, ShopListRequestViewModel viewModel)
        {
            entity.CheckoutFK = viewModel.CheckoutFK;
            entity.FreeDelivery = viewModel.FreeDelivery;
            entity.Active = viewModel.Active;
            entity.UpdatedAt = DateTime.Now;

            return entity;
        }
    }
}