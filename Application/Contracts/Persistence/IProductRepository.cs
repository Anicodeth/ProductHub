using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.ProductDTOs;
using Domain.Entities;

namespace Application.Contracts.Persistence
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO> GetProductByIdAsync(int productId);
        Task<ProductDTO> CreateProductAsync(ProductCreationDTO createProductDto);
        Task<ProductDTO> UpdateProductAsync(int productId, ProductUpdateDTO updateProductDto);
        Task<bool> DeleteProductAsync(int productId);
        Task<IEnumerable<ProductDTO>> SearchProductsAsync(ProductSearchDTO searchDto);

        Task<IEnumerable<Category>> GetAllCategoriesAsync();


    }
}
