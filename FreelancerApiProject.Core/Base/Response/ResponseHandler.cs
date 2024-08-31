using System.Net;
using FreelancerApiProject.Core.Base.Resources;
using Microsoft.Extensions.Localization;

namespace FreelancerApiProject.Core.Base.Response
{
    public class ResponseHandler
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        // Constructor to inject the string localizer
        protected ResponseHandler(IStringLocalizer<SharedResources> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }

        // Method to create a response for deleted entities
        protected Response<T> Deleted<T>(string? message = null)
        {
            return new Response<T>
            {
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = message ?? _stringLocalizer[SharedResourcesKeys.Deleted]
            };
        }

        // Method to create a successful response with data and optional message and metadata
        protected Response<T> Success<T>(T entity, string? message = null, object? meta = null)
        {
            return new Response<T>
            {
                Data = entity,
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = message ?? _stringLocalizer[SharedResourcesKeys.Success],
                Meta = meta
            };
        }

        // Method to create an unauthorized response
        public Response<T> Unauthorized<T>(string? message = null)
        {
            return new Response<T>
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Succeeded = false,
                Message = message ?? _stringLocalizer[SharedResourcesKeys.UnAuthorized]
            };
        }

        // Method to create a bad request response
        protected Response<T> BadRequest<T>(string? message = null)
        {
            return new Response<T>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = message ?? _stringLocalizer[SharedResourcesKeys.BadRequest]
            };
        }

        // Method to create an unprocessable entity response
        public Response<T> UnprocessableEntity<T>(string? message = null)
        {
            return new Response<T>
            {
                StatusCode = HttpStatusCode.UnprocessableEntity,
                Succeeded = false,
                Message = message ?? _stringLocalizer[SharedResourcesKeys.UnprocessableEntity]
            };
        }

        // Method to create a not found response
        protected Response<T> NotFound<T>(string? message = null)
        {
            return new Response<T>
            {
                StatusCode = HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message ?? _stringLocalizer[SharedResourcesKeys.NotFound]
            };
        }

        // Method to create a created response with data and optional metadata
        protected Response<T> Created<T>(T entity, object? meta = null)
        {
            return new Response<T>
            {
                Data = entity,
                StatusCode = HttpStatusCode.Created,
                Succeeded = true,
                Message = _stringLocalizer[SharedResourcesKeys.Created],
                Meta = meta
            };
        }
    }
}