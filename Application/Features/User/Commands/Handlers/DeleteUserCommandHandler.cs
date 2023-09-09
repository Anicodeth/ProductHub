using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.DTOs.UserDTOs;
using Application.Features.User.Commands.Requests;
using AutoMapper;
using MediatR;

namespace Application.Features.User.Commands.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {

            var result = await _userRepository.DeleteUserAsync(request.UserId);
            return result;
        }
    }


}
