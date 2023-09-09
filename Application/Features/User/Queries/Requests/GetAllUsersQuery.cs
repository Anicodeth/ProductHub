using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.UserDTOs;
using MediatR;

namespace Application.Features.User.Queries.Requests
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserDTO>>
    {
    }

}
