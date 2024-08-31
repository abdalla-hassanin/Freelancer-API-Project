using AutoMapper;
using FreelancerApiProject.Core.MediatrHandlers.Auth.Commands.Models;
using FreelancerApiProject.Service.DTO;

namespace FreelancerApiProject.Core.Mapping.Auth
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<RegisterCommand, RegisterModel>();
            CreateMap<LoginCommand, LoginModel>();
            CreateMap<ResetPasswordCommand, ResetPasswordModel>();
            CreateMap<ChangePasswordCommand, ChangePasswordModel>();
            CreateMap<RefreshTokenCommand, RefreshTokenModel>();
            CreateMap<RevokeTokenCommand, RevokeTokenModel>();
            CreateMap<ResendEmailConfirmationCommand, ResendEmailConfirmationModel>();
            CreateMap<CheckTokenValidityCommand, CheckTokenValidityModel>();
        }
    }
}