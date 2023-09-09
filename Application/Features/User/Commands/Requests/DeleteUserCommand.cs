using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.User.Commands.Requests
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public int UserId { get; set; }
    }

}
