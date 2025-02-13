using ElPalacio.Domain.Entities;
using ElPalacio.Domain.IConverter;
using ElPalacio.Domain.IManager;
using ElPalacio.Domain.IRepository;
using ElPalacio.Domain.ViewModel;
using ElPalacio.Domain.ViewModel.Requests;

namespace ElPalacio.Domain.Manager
{
    public class CheckoutManager : BaseManager<Checkout, CheckoutRequestViewModel, CheckoutViewModel>, ICheckoutManager
    {
        private readonly ICheckoutRepository _repository;
        private readonly ICheckoutConverter _converter;

        public CheckoutManager(ICheckoutConverter converter, ICheckoutRepository repository) : base(converter, repository)
        {
            _converter = converter;
            _repository = repository;
        }
    }
}