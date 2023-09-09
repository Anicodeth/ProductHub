using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.DTOs.ProductDTOs;
using Application.Features.Product.Commands.Handlers;
using Application.Features.Product.Commands.Requests;
using AutoMapper;
using Moq;
using Xunit;

public class UpdateProductCommandHandlerTests
{
    [Fact]
    public async Task Handle_ValidRequest_ShouldReturnUpdatedProductDTO()
    {
        // Arrange
        var mockProductRepository = new Mock<IProductRepository>();
        var mockMapper = new Mock<IMapper>();

        var handler = new UpdateProductCommandHandler(mockProductRepository.Object, mockMapper.Object);

        var request = new UpdateProductCommand
        {
            ProductId = 1, // Provide an existing product ID
            ProductUpdateDTO = new ProductUpdateDTO
            {
                Name = "Updated Product",
                Description = "Updated Description",
                Pricing = 25.99m,
                Availability = 15,
                // Initialize other properties as needed for the update
            }
        };

        var cancellationToken = new CancellationToken();

        var updatedProduct = new ProductDTO
        {
            ProductId = 1,
            Name = "Updated Product",
            Description = "Updated Description",
            Pricing = 25.99m,
            Availability = 15,
            // Initialize other properties as needed for the updated product
        };

        mockProductRepository
            .Setup(repo => repo.UpdateProductAsync(request.ProductId, request.ProductUpdateDTO))
            .ReturnsAsync(updatedProduct);

        mockMapper
            .Setup(mapper => mapper.Map<ProductDTO>(updatedProduct))
            .Returns(updatedProduct);

        // Act
        var result = await handler.Handle(request, cancellationToken);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<ProductDTO>(result);
        // Add more specific assertions based on your application's update logic
    }
}
