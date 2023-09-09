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
using Domain.Entities;

namespace Application.Features.Product.Commands.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDTO>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDTO> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
    
            var createdProduct = await _productRepository.CreateProductAsync(request.ProductCreationDTO);
            return _mapper.Map<ProductDTO>(createdProduct);
        }
    }

}
