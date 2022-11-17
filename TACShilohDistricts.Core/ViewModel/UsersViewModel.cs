using TACShilohDistricts.Core.DTOs.AppUserDtos;

namespace TACShilohDistricts.Core.ViewModel
{
    public class UsersViewModel
    {
        public IEnumerable<AddUserResponseDto> AddUserResponse { get; set; }
        public string Email { get; set; }
    }
}
