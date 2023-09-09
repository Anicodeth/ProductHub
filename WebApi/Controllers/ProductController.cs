using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs.ProductDTOs;
using MediatR;
using Application.Features.Product.Commands.Requests;
using Application.Features.Product.Queries.Requests;
using Domain.Entities;

namespace YourNamespace.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> CreateProduct([FromBody] ProductCreationDTO createProductDTO)
        {
            var createProductCommand = new CreateProductCommand { ProductCreationDTO = createProductDTO };
            var createdProduct = await _mediator.Send(createProductCommand);
            return Ok(createdProduct);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int productId)
        {
            var getProductQuery = new GetProductQuery { ProductId = productId };
            var product = await _mediator.Send(getProductQuery);

            if (product == null)
            {
                return NotFound(); // Product not found
            }

            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts()
        {
            var getAllProductsQuery = new GetAllProductsQuery();
            var products = await _mediator.Send(getAllProductsQuery);
            return Ok(products);
        }

        [HttpPut("{productId}")]
        public async Task<ActionResult<ProductDTO>> UpdateProduct(int productId, [FromBody] ProductUpdateDTO updateProductDTO)
        {
            var updateProductCommand = new UpdateProductCommand { ProductId = productId, ProductUpdateDTO = updateProductDTO };
            try
            {
                var updatedProduct = await _mediator.Send(updateProductCommand);
                return Ok(updatedProduct);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message); // Product not found
            }
        }

        [HttpDelete("{productId}")]
        public async Task<ActionResult<bool>> DeleteProduct(int productId)
        {
            var deleteProductCommand = new DeleteProductCommand { ProductId = productId };
            try
            {
                var result = await _mediator.Send(deleteProductCommand);
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message); // Product not found
            }
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IEnumerable<Category>>> GetProductCategories()
        {
            var getCategoriesQuery = new GetProductCategoriesQuery();
            var categories = await _mediator.Send(getCategoriesQuery);
            return Ok(categories);
        }
    }
}
