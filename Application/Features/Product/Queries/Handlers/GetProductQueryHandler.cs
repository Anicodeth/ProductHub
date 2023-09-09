using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.DTOs.ProductDTOs;
using Application.Features.Product.Queries.Requests;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Queries.Handlers
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDTO>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDTO> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var productId = request.ProductId;
            var product = await _productRepository.GetProductByIdAsync(productId);

            if (product == null)
            {
                throw new NotFoundException("Product not found");
            }

            return _mapper.Map<ProductDTO>(product);
        }
    }

}
