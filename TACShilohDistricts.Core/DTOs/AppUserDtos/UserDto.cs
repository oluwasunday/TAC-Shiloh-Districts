using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TACShilohDistricts.Core.DTOs.AppUserDtos
{
    public class UserDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Enter valid email")]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
    }

    public class AddUserResponseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string PictureUrl { get; set; }
        public int Age { get; set; }
        public string UserRole { get; set; }
        public string Status { get; set; }
        public int TotalMembers { get; set; }
        public int TotalProphets { get; set; }
        public int TotalPastors { get; set; }
        public int TotalElders { get; set; }
    }

    public class UpdateUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class RegisterResponseDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string PublicId { get; set; }
        public string Avatar { get; set; }
    }

    public class RegisterDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string PublicId { get; set; }
        public string Avatar { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponseDto
    {
        public string Id { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Avatar { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> Roles { get; set; }
    }

    public class ResetPasswordDto
    {
        public string Token { get; set; }

        public string Email { get; set; }

        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "New Password and Confirm Password must match.")]
        public string ConfirmPassword { get; set; }
    }

    public class UsersRolesDto
    {
        public int TotalMembers { get; set; }
        public int TotalPastors { get; set; }
        public int TotalProphets { get; set; }
        public int TotalElders { get; set; }
    }
}
