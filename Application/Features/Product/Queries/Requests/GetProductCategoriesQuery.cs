using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Domain.Entities;

namespace Application.Features.Product.Queries.Requests
{
    public class GetProductCategoriesQuery : IRequest<IEnumerable<Category>>
    {
    }

}
