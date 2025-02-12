using ElPalacio.Domain.Entities;
using ElPalacio.Domain.ViewModel;
using ElPalacio.Domain.ViewModel.Requests;

namespace ElPalacio.Domain.IConverter
{
    public interface IProductConverter : IConverter<Product, ProductRequestViewModel, ProductViewModel>
    {
    }
}
