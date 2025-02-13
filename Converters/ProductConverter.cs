using ElPalacio.Domain.Entities;
using ElPalacio.Domain.IConverter;
using ElPalacio.Domain.ViewModel;
using ElPalacio.Domain.ViewModel.Requests;
using System.ComponentModel;

namespace ElPalacio.Domain.Converters
{
    public class ProductConverter : IConverter<Product, ProductRequestViewModel, ProductViewModel>, IProductConverter
    {
        public ProductViewModel Convert(Product product)
        {
            var productViewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Sku = product.Sku,
                StockQuantity = product.StockQuantity,
                CategoryFK = product.CategoryFK,
                Active = product.Active,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt
            };

            return productViewModel;
        }

        /// <summary>
        /// Convert a List to Model of the Concept Entity
        /// </summary>
        /// <returns>The list converted</returns>
        /// <param name="charges">charges.</param>
        public List<ProductViewModel> ConvertList(IEnumerable<Product> product)
        {
            return product.Select(component =>
            {
                var productViewModel = new ProductViewModel
                {
                    Id = component.Id,
                    Name = component.Name,
                    Description = component.Description,
                    Sku = component.Sku,
                    StockQuantity = component.StockQuantity,
                    CategoryFK = component.CategoryFK,
                    Active = component.Active,
                    CreatedAt = component.CreatedAt,
                    UpdatedAt = component.UpdatedAt
                };

                return productViewModel;
            }).ToList();
        }
        public Product PrepareAddData(ProductRequestViewModel viewModel)
        {
            return new Product()
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                Sku = viewModel.Sku,
                StockQuantity = viewModel.StockQuantity,
                CategoryFK = viewModel.CategoryFK,
                Active = viewModel.Active,
                CreatedAt = DateTime.Now,
            };
        }

        public Product PrepareUpdateData(Product entity, ProductRequestViewModel viewModel)
        {
            entity.Name = viewModel.Name;
            entity.Description = viewModel.Description;
            entity.Sku = viewModel.Sku;
            entity.StockQuantity = viewModel.StockQuantity;
            entity.CategoryFK = viewModel.CategoryFK;
            entity.Active = viewModel.Active;
            entity.UpdatedAt = DateTime.Now;

            return entity;
        }
    }
}