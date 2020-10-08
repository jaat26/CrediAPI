using CrediAPI.Data.Entities;
using CrediAPI.Models;
using CrediAPI.Models.Request;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CrediAPI.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

        Task<SignInResult> LoginAsync(LoginRequest request);

        Task LogoutAsync();

        Task<SignInResult> ValidatePasswordAsync(User user, string password);

        Task<IdentityResult> UpdateUserAsync(User user);

        Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword);
    }
}
