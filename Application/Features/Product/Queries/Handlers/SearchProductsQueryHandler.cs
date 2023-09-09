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
    public class SearchProductsQueryHandler : IRequestHandler<SearchProductsQuery, IEnumerable<ProductDTO>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public SearchProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> Handle(SearchProductsQuery request, CancellationToken cancellationToken)
        {
            var searchDTO = request.ProductSearchDTO;
            var products = await _productRepository.SearchProductsAsync(searchDTO);
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }
    }

}
