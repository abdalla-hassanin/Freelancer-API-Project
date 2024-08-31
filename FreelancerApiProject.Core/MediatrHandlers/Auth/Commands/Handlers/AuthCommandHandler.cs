using System.Security.Claims;
using AutoMapper;
using FreelancerApiProject.Core.Base.Resources;
using FreelancerApiProject.Core.Base.Response;
using FreelancerApiProject.Core.MediatrHandlers.Auth.Commands.Models;
using FreelancerApiProject.Data.Entities;
using FreelancerApiProject.Service.DTO;
using FreelancerApiProject.Service.IServices;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;

namespace FreelancerApiProject.Core.MediatrHandlers.Auth.Commands.Handlers
{
    public class AuthCommandHandler : ResponseHandler,
        IRequestHandler<RegisterCommand, Response<AuthModel>>,
        IRequestHandler<LoginCommand, Response<AuthModel>>,
        IRequestHandler<LogoutCommand, Response<string>>,
        IRequestHandler<ForgetPasswordCommand, Response<string>>,
        IRequestHandler<ResetPasswordCommand, Response<string>>,
        IRequestHandler<ChangePasswordCommand, Response<string>>,
        IRequestHandler<RefreshTokenCommand, Response<AuthModel>>,
        IRequestHandler<RevokeTokenCommand, Response<string>>,
        IRequestHandler<ResendEmailConfirmationCommand, Response<string>>,
        IRequestHandler<CheckTokenValidityCommand, Response<bool>>
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public AuthCommandHandler(IAuthService authService, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _authService = authService;
            _mapper = mapper;
            _localizer = localizer;
        }

        public async Task<Response<AuthModel>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var result = await _authService.RegisterAsync(_mapper.Map<RegisterModel>(request));
            return result.IsAuthenticated ? Success(result) : BadRequest<AuthModel>(result.Message);
        }

        public async Task<Response<AuthModel>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result = await _authService.LoginAsync(_mapper.Map<LoginModel>(request));
            return result.IsAuthenticated ? Success(result) : BadRequest<AuthModel>(result.Message);
        }

        public async Task<Response<string>> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            var result = await _authService.LogoutAsync();
            return result.Message == "Logout successful." ? Success(result.Message) : BadRequest<string>(result.Message);
        }

        public async Task<Response<string>> Handle(ForgetPasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await _authService.ForgetPasswordAsync(request.Email);
            return result.IsAuthenticated ? Success(result.Message) : BadRequest<string>(result.Message);
        }

        public async Task<Response<string>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await _authService.ResetPasswordAsync(_mapper.Map<ResetPasswordModel>(request));
            return result.IsAuthenticated ? Success(result.Message) : BadRequest<string>(result.Message);
        }

        public async Task<Response<string>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {

            var result = await _authService.ChangePasswordAsync(_mapper.Map<ChangePasswordModel>(request));
            return result.IsAuthenticated ? Success(result.Message) : BadRequest<string>(result.Message);
        }

        public async Task<Response<AuthModel>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var result = await _authService.RefreshTokenAsync(request.Token);
            return result.IsAuthenticated ? Success(result) : BadRequest<AuthModel>(result.Message);
        }

        public async Task<Response<string>> Handle(RevokeTokenCommand request, CancellationToken cancellationToken)
        {
            var result = await _authService.RevokeTokenAsync(request.Token);
            return result ? Success("Token revoked successfully.") : BadRequest<string>("Token revocation failed.");
        }

        public async Task<Response<string>> Handle(ResendEmailConfirmationCommand request, CancellationToken cancellationToken)
        {
            var result = await _authService.ResendEmailConfirmationAsync(request.Email);
            return result.IsAuthenticated ? Success(result.Message) : BadRequest<string>(result.Message);
        }

        public async Task<Response<bool>> Handle(CheckTokenValidityCommand request, CancellationToken cancellationToken)
        {
            var result = await _authService.CheckTokenValidityAsync(request.Token);
            return Success(result);
        }
    }
}