using ElPalacio.Domain.Entities;
using ElPalacio.Domain.ViewModel;
using ElPalacio.Domain.ViewModel.Requests;

namespace ElPalacio.Domain.IManager
{
    public interface ICheckoutManager : IBaseManager<Checkout, CheckoutRequestViewModel, CheckoutViewModel>
    {
    }
}