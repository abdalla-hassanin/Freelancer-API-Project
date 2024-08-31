using FreelancerApiProject.Service.DTO;

namespace FreelancerApiProject.Service.IServices
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> ConfirmEmailAsync(string userId, string token);
        Task<AuthModel> LoginAsync(LoginModel model);
        Task<AuthModel> LogoutAsync();
        Task<AuthModel> ForgetPasswordAsync(string email);
        Task<AuthModel> ResetPasswordAsync(ResetPasswordModel model);
        Task<AuthModel> ChangePasswordAsync(ChangePasswordModel model);
        Task<AuthModel> RefreshTokenAsync(string token);
        Task<bool> RevokeTokenAsync(string token);
        Task<AuthModel> ResendEmailConfirmationAsync(string email);
        Task<bool> CheckTokenValidityAsync(string token);
    }
}