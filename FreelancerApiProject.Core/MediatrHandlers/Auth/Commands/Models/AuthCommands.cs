using FreelancerApiProject.Core.Base.Response;
using FreelancerApiProject.Service.DTO;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Auth.Commands.Models
{
    public class RegisterCommand : IRequest<Response<AuthModel>>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
    }

    public class LoginCommand : IRequest<Response<AuthModel>>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LogoutCommand : IRequest<Response<string>>
    {
    }

    public class ForgetPasswordCommand : IRequest<Response<string>>
    {
        public string Email { get; set; }
    }

    public class ResetPasswordCommand : IRequest<Response<string>>
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }

    public class ChangePasswordCommand : IRequest<Response<string>>
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }

    public class RefreshTokenCommand : IRequest<Response<AuthModel>>
    {
        public string Token { get; set; }
    }

    public class RevokeTokenCommand : IRequest<Response<string>>
    {
        public string Token { get; set; }
    }

    public class ResendEmailConfirmationCommand : IRequest<Response<string>>
    {
        public string Email { get; set; }
    }

    public class CheckTokenValidityCommand : IRequest<Response<bool>>
    {
        public string Token { get; set; }
    }
}