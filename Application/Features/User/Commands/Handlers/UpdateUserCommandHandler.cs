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
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDTO>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {

            var updatedUser = await _userRepository.UpdateUserAsync(request.UserId, request.UpdateUserDTO);
            return _mapper.Map<UserDTO>(updatedUser);
        }
    }
}
