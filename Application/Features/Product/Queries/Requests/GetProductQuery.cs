using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.ProductDTOs;
using MediatR;

namespace Application.Features.Product.Queries.Requests
{
    public class GetProductQuery : IRequest<ProductDTO>
    {
        public int ProductId { get; set; }
    }

}
