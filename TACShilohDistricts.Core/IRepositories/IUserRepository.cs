using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TACShilohDistricts.Core.DTOs.AppUserDtos;
using TACShilohDistricts.Core.Entities;
using TACShilohDistricts.Core.Handlers;

namespace TACShilohDistricts.Core.IRepositories
{
    public interface IUserRepository
    {
        Task<AddUserResponseDto> AddUserAsync(UserDto user);
        Task<IEnumerable<AddUserResponseDto>> GetLastTenUsersAsync();
        Task<AddUserResponseDto> GetUserByIdAsync(string id);
        Task<Response<AddUserResponseDto>> GetUserByEmailAsync(string email);
        Task<AddUserResponseDto> UpdateUserAsync(string id, UpdateUserDto user);
        Task<bool> UpdateUserPictureAsync(AppUser user);
        IEnumerable<UserDto> SearchUsersByTerm(string searchTerm);
        Task<bool> SoftDeleteUser(string id);
        Task<UsersRolesDto> AllUsersRoles();
    }
}
