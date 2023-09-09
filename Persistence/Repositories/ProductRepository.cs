using Application.Contracts.Persistence;
using Application.DTOs.ProductDTOs;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence;

public class ProductRepository : IProductRepository
{
    private readonly ProductHubDbContext _context; // Replace with your actual data context
    private readonly IMapper _mapper; // AutoMapper instance

    public ProductRepository(ProductHubDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
    {
        var products = await _context.Products.ToListAsync();
        return _mapper.Map<IEnumerable<ProductDTO>>(products);
    }

    public async Task<ProductDTO> GetProductByIdAsync(int productId)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
        return _mapper.Map<ProductDTO>(product);
    }

    public async Task<ProductDTO> CreateProductAsync(ProductCreationDTO createProductDto)
    {
        var product = _mapper.Map<Product>(createProductDto);
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return _mapper.Map<ProductDTO>(product);
    }

    public async Task<ProductDTO> UpdateProductAsync(int productId, ProductUpdateDTO updateProductDto)
    {
        var existingProduct = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
        if (existingProduct == null)
        {
            return null; // Product not found
        }

        _mapper.Map(updateProductDto, existingProduct); // Update product properties
        await _context.SaveChangesAsync();
        return _mapper.Map<ProductDTO>(existingProduct);
    }

    public async Task<bool> DeleteProductAsync(int productId)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
        if (product == null)
        {
            return false; // Product not found
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<ProductDTO>> SearchProductsAsync(ProductSearchDTO searchDto)
    {
        // Implement search logic based on searchDto properties
        var query = _context.Products.AsQueryable();

        if (!string.IsNullOrEmpty(searchDto.Name))
        {
            query = query.Where(p => p.Name.Contains(searchDto.Name));
        }


        var products = await query.ToListAsync();
        return _mapper.Map<IEnumerable<ProductDTO>>(products);
    }


    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        return await _context.Categories.ToListAsync();
    }
}
