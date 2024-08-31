using System.Net;
using FreelancerApiProject.Core.Base.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FreelancerApiProject.Api.Base
{
    [ApiController]
    public abstract class AppControllerBase : ControllerBase
    {
        private IMediator? _mediator;

        protected IMediator Mediator => (_mediator ??= HttpContext.RequestServices.GetService<IMediator>())!;

        #region Actions

        protected ObjectResult CreateResponse<T>(Response<T> response)
        {
            return response.StatusCode switch
            {
                HttpStatusCode.OK => new OkObjectResult(response),
                HttpStatusCode.Created => new CreatedResult(string.Empty, response),
                HttpStatusCode.Unauthorized => new UnauthorizedObjectResult(response),
                HttpStatusCode.BadRequest => new BadRequestObjectResult(response),
                HttpStatusCode.NotFound => new NotFoundObjectResult(response),
                HttpStatusCode.Accepted => new AcceptedResult(string.Empty, response),
                HttpStatusCode.UnprocessableEntity => new UnprocessableEntityObjectResult(response),
                _ => new BadRequestObjectResult(response),
            };
        }

        #endregion
    }
}
