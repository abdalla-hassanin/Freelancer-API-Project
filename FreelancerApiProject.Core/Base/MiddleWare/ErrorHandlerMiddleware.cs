using System.Net;
using System.Text.Json;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Serilog;
using FreelancerApiProject.Core.Base.Response;

namespace FreelancerApiProject.Core.Base.MiddleWare
{
    // Middleware to handle exceptions and provide custom error responses
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        // Constructor to initialize the ErrorHandlerMiddleware
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next; // Set the next middleware in the pipeline
        }

        // Middleware invocation method
        public async Task Invoke(HttpContext context)
        {
            try
            {
                // Call the next middleware in the pipeline
                await _next(context);
            }
            catch (Exception error)
            {
                // Handle any exceptions that occur
                var response = context.Response;
                response.ContentType = "application/json"; // Set the response content type to JSON
                var responseModel = new Response<string>() { Succeeded = false, Message = error?.Message }; // Create a response model

                // Log the error using Serilog
                Log.Error(error, error.Message, context.Request, "");

                // Determine the type of exception and set the appropriate response status code and message
                switch (error)
                {
                    case UnauthorizedAccessException e:
                        // Handle unauthorized access exceptions
                        responseModel.Message = error.Message;
                        responseModel.StatusCode = HttpStatusCode.Unauthorized; // Set the status code for unauthorized access
                        response.StatusCode = (int)HttpStatusCode.Unauthorized; // Update the response status code
                        break;

                    case ValidationException e:
                        // Handle validation exceptions
                        responseModel.Message = error.Message;
                        responseModel.StatusCode = HttpStatusCode.UnprocessableEntity; // Set the status code for validation errors
                        response.StatusCode = (int)HttpStatusCode.UnprocessableEntity; // Update the response status code
                        break;

                    case KeyNotFoundException e:
                        // Handle not found exceptions
                        responseModel.Message = error.Message;
                        responseModel.StatusCode = HttpStatusCode.NotFound; // Set the status code for not found
                        response.StatusCode = (int)HttpStatusCode.NotFound; // Update the response status code
                        break;

                    case DbUpdateException e:
                        // Handle database update exceptions
                        responseModel.Message = e.Message;
                        responseModel.StatusCode = HttpStatusCode.BadRequest; // Set the status code for bad requests
                        response.StatusCode = (int)HttpStatusCode.BadRequest; // Update the response status code
                        break;

                    case Exception e when e.GetType().ToString() == "ApiException":
                        // Handle API exceptions
                        responseModel.Message += e.Message; // Add the exception message
                        responseModel.Message += e.InnerException == null ? "" : "\n" + e.InnerException.Message; // Add inner exception message if present
                        responseModel.StatusCode = HttpStatusCode.BadRequest; // Set the status code for bad requests
                        response.StatusCode = (int)HttpStatusCode.BadRequest; // Update the response status code
                        break;

                    default:
                        // Handle all other unhandled exceptions
                        responseModel.Message = error.Message; // Set the error message
                        responseModel.StatusCode = HttpStatusCode.InternalServerError; // Set the status code for internal server error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError; // Update the response status code
                        break;
                }

                // Serialize the response model to JSON and write it to the response
                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result); // Send the serialized response
            }
        }
    }
}
