using ElPalacio.Domain.Entities;
using ElPalacio.Domain.IConverter;
using ElPalacio.Domain.ViewModel;
using ElPalacio.Domain.ViewModel.Requests;

namespace ElPalacio.Domain.Converters
{
    public class CheckoutConverter : IConverter<Checkout, CheckoutRequestViewModel, CheckoutViewModel>, ICheckoutConverter
    {
        public CheckoutViewModel Convert(Checkout checkout)
        {
            var categoryViewModel = new CheckoutViewModel
            {
                Id = checkout.Id,
                BankCardFK = checkout.BankCardFK,
                PriceFK = checkout.PriceFK,
                SubTotal = checkout.SubTotal,
                DeliveryFee = checkout.DeliveryFee,
                Total = checkout.Total,
                Active = checkout.Active,
                CreatedAt = checkout.CreatedAt,
                UpdatedAt = checkout.UpdatedAt

            };

            return categoryViewModel;
        }

        public List<CheckoutViewModel> ConvertList(IEnumerable<Checkout> checkout)
        {
            return checkout.Select(b =>
            {
                var model = new CheckoutViewModel
                {
                    Id = b.Id,
                    BankCardFK = b.BankCardFK,
                    PriceFK = b.PriceFK,
                    SubTotal = b.SubTotal,
                    DeliveryFee = b.DeliveryFee,
                    Total = b.Total,
                    Active = b.Active,
                    CreatedAt = b.CreatedAt,
                    UpdatedAt = b.UpdatedAt
                };

                return model;
            }).ToList();
        }

        public Checkout PrepareAddData(CheckoutRequestViewModel viewModel)
        {
            return new Checkout()
            {
                BankCardFK = viewModel.BankCardFK,
                PriceFK = viewModel.PriceFK,
                SubTotal = viewModel.SubTotal,
                DeliveryFee = viewModel.DeliveryFee,
                Total = viewModel.Total,
                Active = viewModel.Active,
                CreatedAt = DateTime.Now,
            };
        }

        public Checkout PrepareUpdateData(Checkout entity, CheckoutRequestViewModel viewModel)
        {
            entity.BankCardFK = viewModel.BankCardFK;
            entity.PriceFK = viewModel.PriceFK;
            entity.SubTotal = viewModel.SubTotal;
            entity.DeliveryFee = viewModel.DeliveryFee;
            entity.Total = viewModel.Total;
            entity.Active = viewModel.Active;
            entity.UpdatedAt = DateTime.Now;

            return entity;
        }
    }
}
