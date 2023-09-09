using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs.UserDTOs;
using MediatR;
using Application.Features.User.Commands.Requests;
using Application.Features.User.Queries.Requests;

namespace YourNamespace.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUser([FromBody] CreateUserDTO createUserDTO)
        {
            var createUserCommand = new CreateUserCommand { CreateUserDTO = createUserDTO };
            var createdUser = await _mediator.Send(createUserCommand);
            return Ok(createdUser);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserDTO>> GetUser(int userId)
        {
            var getUserQuery = new GetUserQuery { UserId = userId };
            var user = await _mediator.Send(getUserQuery);

            if (user == null)
            {
                return NotFound(); // User not found
            }

            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            var getAllUsersQuery = new GetAllUsersQuery();
            var users = await _mediator.Send(getAllUsersQuery);
            return Ok(users);
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult<UserDTO>> UpdateUser(int userId, [FromBody] UpdateUserDTO updateUserDTO)
        {
            var updateCommand = new UpdateUserCommand { UserId = userId, UpdateUserDTO = updateUserDTO };
            try
            {
                var updatedUser = await _mediator.Send(updateCommand);
                return Ok(updatedUser);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message); // User not found
            }
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult<bool>> DeleteUser(int userId)
        {
            var deleteCommand = new DeleteUserCommand { UserId = userId };
            try
            {
                var result = await _mediator.Send(deleteCommand);
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message); // User not found
            }
        }
    }
}

