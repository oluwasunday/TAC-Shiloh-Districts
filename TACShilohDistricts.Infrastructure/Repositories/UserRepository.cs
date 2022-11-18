using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TACShilohDistricts.Core.DTOs.AppUserDtos;
using TACShilohDistricts.Core.Entities;
using TACShilohDistricts.Core.Handlers;
using TACShilohDistricts.Core.IRepositories;
using TACShilohDistricts.Infrastructure.Data;

namespace TACShilohDistricts.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TACShilohContext _dbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        public UserRepository(TACShilohContext dbContext, UserManager<AppUser> userManager, IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        public async Task<AddUserResponseDto> AddUserAsync(UserDto user)
        {
            AppUser appUser = _mapper.Map<AppUser>(user);

            if (appUser == null)
            {
                throw new ArgumentNullException(nameof(appUser));
            }

            IdentityResult result = await _userManager.CreateAsync(appUser, user.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(appUser, "Customer");
                var response = _mapper.Map<AddUserResponseDto>(appUser);
                return response;
            }

            string errors = string.Empty;
            foreach (var error in result.Errors)
            {
                errors += error.Description + Environment.NewLine;
            }

            throw new MissingFieldException(errors);
        }

        public async Task<IEnumerable<AddUserResponseDto>> GetLastTenUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            users = users.Where(x => x.IsActive == true).OrderByDescending(x => x.CreatedAt).Take(10).ToList();
            //users.ForEach(x => x.UserRole = _userManager.GetRolesAsync(x));
            var response = new List<AddUserResponseDto>();
            

            if (users != null)
            {
                foreach (var user in users)
                {
                    string? role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
                    response.Add(new AddUserResponseDto
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        Gender = user.Gender,
                        Age = user.Age,
                        PhoneNumber = user.PhoneNumber,
                        PictureUrl = user.PictureUrl,
                        UserName = user.UserName,
                        UserRole = role ?? "no role",
                        Status = user.IsActive ? "Active" : "Inactive"
                    });
                }

                //var response = _mapper.Map<List<AddUserResponseDto>>(users);                
                return response;
            }
            throw new ArgumentException("User not found!");
        }

        public async Task<AddUserResponseDto> GetUserByIdAsync(string id)
        {

            AppUser appUser = await _userManager.FindByIdAsync(id);
            if (appUser != null)
            {
                var response = _mapper.Map<AddUserResponseDto>(appUser);
                return response;
            }

            throw new KeyNotFoundException("User not found!");
        }


        public async Task<Response<AddUserResponseDto>> GetUserByEmailAsync(string email)
        {
            AppUser appUser = await _userManager.FindByEmailAsync(email);
            if (appUser != null)
            {
                var response = _mapper.Map<AddUserResponseDto>(appUser);
                return Response<AddUserResponseDto>.Success("success", response);
            }
            return Response<AddUserResponseDto>.Fail("failed");
        }


        public async Task<AddUserResponseDto> UpdateUserAsync(string id, UpdateUserDto user)
        {
            var appUser = await _userManager.f.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (appUser == null)
            {
                throw new ArgumentNullException("User not found.");
            }

            appUser.FirstName = user.FirstName;
            appUser.LastName = user.LastName;
            appUser.Email = user.Email;
            appUser.PhoneNumber = user.PhoneNumber;

            await _userManager.UpdateAsync(appUser);

            var response = _mapper.Map<AddUserResponseDto>(appUser);
            return response;
        }


        public async Task<bool> UpdateUserPictureAsync(AppUser user)
        {

            var appUser = _userManager.Users.FirstOrDefault(x => x.Id == user.Id);
            if (appUser == null)
            {
                throw new ArgumentNullException("User not found.");
            }

            appUser.PictureUrl = user.PictureUrl;

            var result = await _userManager.UpdateAsync(appUser);
            if (result.Succeeded)
                return true;

            return false;
        }


        public IEnumerable<UserDto> SearchUsersByTerm(string searchTerm)
        {
            var user = _userManager.Users.Where(x =>
                x.FirstName.Contains(searchTerm) ||
                x.LastName.Contains(searchTerm) ||
                x.Email.Contains(searchTerm) ||
                x.PhoneNumber.Contains(searchTerm))
                .ToList();

            if (user != null)
            {
                var userDto = _mapper.Map<List<UserDto>>(user);
                return userDto;
            }
                

            throw new KeyNotFoundException("No item found!");
        }

        public Task<bool> SoftDeleteUser(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<UsersRolesDto> AllUsersRoles()
        {
            var totalProphets = 0;
            var totalPastors = 0;
            var totalElders = 0;
            var totalMembers = 0;

            var allUsers = _dbContext.Roles.ToList();

            /*var prophetRoleId = _dbContext.Roles.Where(x => x.Name == "Prophet").FirstOrDefault().Id;
            totalProphets = _dbContext.UserRoles.Where(x => x.RoleId == prophetRoleId).Count();

            var eldersRoleId = _dbContext.Roles.Where(x => x.Name == "Elder").FirstOrDefault().Id;
            totalElders = _dbContext.UserRoles.Where(x => x.RoleId == eldersRoleId).Count();

            var pastorsRoleId = _dbContext.Roles.Where(x => x.Name == "Pastor").FirstOrDefault().Id;
            totalPastors = _dbContext.UserRoles.Where(x => x.RoleId == pastorsRoleId).Count();

            var membersRoleIds = _dbContext.Roles.Where(x => x.Name == "Member" || x.Name == "Admin").Select(x => x.Id).ToList();
            totalMembers = _dbContext.UserRoles.Where(x => membersRoleIds.Contains(x.RoleId)).Count();*/
            
            foreach (var user in allUsers)
            {
                if(user.Name == "Elder")
                    totalElders += (_dbContext.UserRoles.Where(x => x.RoleId == user.Id)).Count();
                if(user.Name == "Member" || user.Name == "Admin")
                    totalMembers += (_dbContext.UserRoles.Where(x => x.RoleId == user.Id)).Count();
                if(user.Name == "Prophet")
                    totalProphets += (_dbContext.UserRoles.Where(x => x.RoleId == user.Id)).Count();
                if(user.Name == "Pastor")
                    totalPastors += (_dbContext.UserRoles.Where(x => x.RoleId == user.Id)).Count();
            }

            return new UsersRolesDto
            {
                TotalElders = totalElders,
                TotalMembers = totalMembers,
                TotalPastors = totalPastors,
                TotalProphets = totalProphets,
            };
        }
    }
}
