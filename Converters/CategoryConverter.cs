using ElPalacio.Domain.Entities;
using ElPalacio.Domain.IConverter;
using ElPalacio.Domain.ViewModel;
using ElPalacio.Domain.ViewModel.Requests;

namespace ElPalacio.Domain.Converters
{
    public class CategoryConverter : IConverter<Category, CategoryRequestViewModel, CategoryViewModel>, ICategoryConverter
    {
        public CategoryViewModel Convert(Category category)
        {
            var categoryViewModel = new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Active = category.Active,
                CreatedAt = category.CreatedAt,
                UpdatedAt = category.UpdatedAt

            };

            return categoryViewModel;
        }

        public List<CategoryViewModel> ConvertList(IEnumerable<Category> category)
        {
            return category.Select(b =>
            {
                var model = new CategoryViewModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    Active = b.Active,
                    CreatedAt = b.CreatedAt,
                    UpdatedAt = b.UpdatedAt
                };

                return model;
            }).ToList();
        }

        public Category PrepareAddData(CategoryRequestViewModel viewModel)
        {
            return new Category()
            {
                Name = viewModel.Name,
                Active = viewModel.Active,
                CreatedAt = DateTime.Now,
            };
        }

        public Category PrepareUpdateData(Category entity, CategoryRequestViewModel viewModel)
        {
            entity.Name = viewModel.Name;
            entity.Active = viewModel.Active;
            entity.UpdatedAt = DateTime.Now;

            return entity;
        }
    }
}