using FreelancerApiProject.Core.Base.Resources;
using FreelancerApiProject.Core.Base.Response;
using FreelancerApiProject.Service.IServices;
using MediatR;
using Microsoft.Extensions.Localization;

namespace FreelancerApiProject.Core.MediatrHandlers.Auth.Queries
{
    public class AuthQueryHandler : ResponseHandler, IRequestHandler<ConfirmEmailQuery, Response<string>>
    {
        private readonly IAuthService _authService;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public AuthQueryHandler(IAuthService authService, IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _authService = authService;
            _localizer = localizer;
        }

        public async Task<Response<string>> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
        {
            var result = await _authService.ConfirmEmailAsync(request.UserId, request.Token);
            return result.IsAuthenticated ? Success(result.Message) : BadRequest<string>(result.Message);
        }
    }
}