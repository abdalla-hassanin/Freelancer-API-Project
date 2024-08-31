using FreelancerApiProject.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace FreelancerApiProject.Infrustructure.IRepositories
{
    public interface IApplicationUserRepository
    {
        Task<ApplicationUser> GetByIdAsync(string id);
        Task<ApplicationUser> GetByEmailAsync(string email);
        Task<IdentityResult> InsertAsync(ApplicationUser user, string role, string password = null);

    }
}
