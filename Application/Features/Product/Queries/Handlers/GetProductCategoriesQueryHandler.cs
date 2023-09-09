using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Features.Product.Queries.Requests;
using AutoMapper;
using MediatR;
using Domain.Entities;

namespace Application.Features.Product.Queries.Handlers
{
    public class GetProductCategoriesQueryHandler : IRequestHandler<GetProductCategoriesQuery, IEnumerable<Category>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductCategoriesQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Category>> Handle(GetProductCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _productRepository.GetAllCategoriesAsync();
            return _mapper.Map<IEnumerable<Category>>(categories);
        }
    }

}
