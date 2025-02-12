using ElPalacio.Domain.Entities;
using ElPalacio.Domain.ViewModel;
using ElPalacio.Domain.ViewModel.Requests;

namespace ElPalacio.Domain.IConverter
{
    public interface ICategoryConverter : IConverter<Category, CategoryRequestViewModel, CategoryViewModel>
    {
    }
}
