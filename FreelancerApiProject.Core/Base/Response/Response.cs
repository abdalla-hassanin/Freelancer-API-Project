using System.Net;

namespace FreelancerApiProject.Core.Base.Response
{
    public class Response<T>
    {
        // Default constructor
        public Response()
        {
        }

        // Constructor for successful responses with data and optional message
        public Response(T data, string? message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
            StatusCode = HttpStatusCode.OK;
        }

        // Constructor for failed responses with a message
        public Response(string? message)
        {
            Succeeded = false;
            Message = message;
        }

        // Constructor for responses with a message and success status
        public Response(string? message, bool succeeded)
        {
            Succeeded = succeeded;
            Message = message;
        }

        // HTTP status code of the response
        public HttpStatusCode StatusCode { get; set; }

        // Additional metadata related to the response
        public object? Meta { get; set; }

        // Indicates whether the request was successful
        public bool Succeeded { get; set; }

        // Message providing additional information about the response
        public string? Message { get; set; }

        // List of errors encountered during the request
        public List<string> Errors { get; set; }

        // Data payload of the response
        public T Data { get; set; }
    }
}