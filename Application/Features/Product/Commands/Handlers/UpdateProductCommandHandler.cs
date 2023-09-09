using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.DTOs.ProductDTOs;
using Application.Features.Product.Commands.Requests;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Commands.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDTO>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDTO> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var updatedProduct = await _productRepository.UpdateProductAsync(request.ProductId, request.ProductUpdateDTO);
            return _mapper.Map<ProductDTO>(updatedProduct);
        }
    }

}
