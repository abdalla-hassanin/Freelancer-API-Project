using FreelancerApiProject.Core.Base.Response;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Auth.Queries
{
    public class ConfirmEmailQuery : IRequest<Response<string>>
    {
        public string UserId { get; set; }
        public string Token { get; set; }

        public ConfirmEmailQuery(string userId, string token)
        {
            UserId = userId;
            Token = token;
        }
    }
}