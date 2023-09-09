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
using Domain.Entities;

namespace Application.Features.User.Commands.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDTO>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var createdUser = await _userRepository.CreateUserAsync(request.CreateUserDTO);
            return _mapper.Map<UserDTO>(createdUser);
        }
    }

}
