using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.DTOs.ProductDTOs;
using Application.Features.Product.Queries.Handlers;
using Application.Features.Product.Queries.Requests;
using AutoMapper;
using Moq;
using Xunit;

public class GetAllProductsQueryHandlerTests
{
    [Fact]
    public async Task Handle_ValidRequest_ShouldReturnListOfProductDTOs()
    {
        // Arrange
        var mockProductRepository = new Mock<IProductRepository>();
        var mockMapper = new Mock<IMapper>();

        var handler = new GetAllProductsQueryHandler(mockProductRepository.Object, mockMapper.Object);

        var query = new GetAllProductsQuery();
        var cancellationToken = new CancellationToken();

        var products = new List<ProductDTO>
        {
             new ProductDTO
            {
                ProductId = 1,
                Name = "Product 1",
                Description = "Description 1",
                Pricing = 19.99m,
                Availability = 10,
                UserId = 1
                // Initialize other properties as needed
            },
            new ProductDTO
            {
                ProductId = 2,
                Name = "Product 2",
                Description = "Description 2",
                Pricing = 29.99m,
                Availability = 5,
                UserId = 1
                // Initialize other properties as needed
            },
        };

        mockProductRepository
            .Setup(repo => repo.GetAllProductsAsync())
            .ReturnsAsync(products);

        mockMapper
            .Setup(mapper => mapper.Map<IEnumerable<ProductDTO>>(It.IsAny<List<ProductDTO>>()))
            .Returns(products);

        // Act
        var result = await handler.Handle(query, cancellationToken);

        // Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<IEnumerable<ProductDTO>>(result);
        Assert.Equal(products.Count, result.Count());

        // You can add more specific assertions based on your application logic
    }
}
