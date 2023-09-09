using Application.Contracts.Persistence;
using Application.DTOs.ProductDTOs;
using Application.Features.Product.Queries.Handlers;
using Application.Features.Product.Queries.Requests;
using AutoMapper;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.Features.CommandTests
{
	public class GetProductQueryHandlerTests
	{
		[Fact]
		public async Task Handle_ValidProductId_ReturnsProductDTO()
		{
			// Arrange
			var productId = 1;
			var productRepositoryMock = new Mock<IProductRepository>();
			var mapperMock = new Mock<IMapper>();

			// Create a sample ProductDTO for testing
			var expectedProductDto = new ProductDTO
			{
				// Initialize with expected values
				ProductId = productId,
				Name = "Sample Product",
				Description = "Sample Description",
				Pricing = 19.99m,
				Availability = 10
				// Add more properties as needed
			};

			// Set up the productRepositoryMock to return the expected ProductDTO
			productRepositoryMock
				.Setup(repo => repo.GetProductByIdAsync(productId))
				.ReturnsAsync(expectedProductDto);

			// Create an instance of GetProductQueryHandler
			var handler = new GetProductQueryHandler(productRepositoryMock.Object, mapperMock.Object);

			// Create a GetProductQuery with the productId
			var query = new GetProductQuery { ProductId = productId };

			// Act
			var result = await handler.Handle(query, CancellationToken.None);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(productId, result.ProductId);
			// Add assertions for other properties as needed

			// Verify that the GetProductByIdAsync method was called with the correct productId
			productRepositoryMock.Verify(repo => repo.GetProductByIdAsync(productId), Times.Once);
		}

		// Add more test cases for error scenarios, such as handling a non-existent product
	}
}
