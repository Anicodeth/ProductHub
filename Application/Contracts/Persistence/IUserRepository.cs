using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.UserDTOs;

namespace Application.Contracts.Persistence
{
    public interface IUserRepository
    {

        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int userId);
        Task<UserDTO> CreateUserAsync(CreateUserDTO createUserDto);
        Task<UserDTO> UpdateUserAsync(int userId, UpdateUserDTO updateUserDto);
        Task<bool> DeleteUserAsync(int userId);


    }

}

