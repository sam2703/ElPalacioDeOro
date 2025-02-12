using ElPalacio.Domain.Entities;
using ElPalacio.Domain.ViewModel;
using ElPalacio.Domain.ViewModel.Requests;

namespace ElPalacio.Domain.IConverter
{
    public interface ICheckoutConverter : IConverter<Checkout, CheckoutRequestViewModel, CheckoutViewModel>
    {
    }
}
