using FreelancerApiProject.Data.Entities;
using FreelancerApiProject.Infrustructure.IRepositories;
using Microsoft.AspNetCore.Identity;

namespace FreelancerApiProject.Infrustructure.Repositories  
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserRepository(UserManager<ApplicationUser> userManager)
        {
           _userManager = userManager;
        }

        public async Task<ApplicationUser> GetByIdAsync(string id)  
        {
            ApplicationUser? user = await _userManager.FindByIdAsync(id);
            return user;
        }

        public async Task<ApplicationUser> GetByEmailAsync(string email) 
        {
            ApplicationUser? user = await _userManager.FindByEmailAsync(email);
            return user;
        }

        public async Task<IdentityResult> InsertAsync(ApplicationUser user , string role, string password = null)  
        {
            IdentityResult result;

            if (password == null)
            {
               result  = await _userManager.CreateAsync(user);
                
            }

            else
            {
               result = await _userManager.CreateAsync(user, password);
            }

            if(result.Succeeded)
            {
                 await _userManager.AddToRoleAsync(user, role);
            }

            return result;
        }

    }
}
