
using System.Text.Json;
using school_api.API.DTOs;
using school_api.Core.Interfaces;
using school_api.Application.Common.Errors;


namespace school_api.API.Middlewares
{

    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }


        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }


        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogWarning(exception.Message);

            ErrorDTO errorResponse = new ErrorDTO
            {
                path = ($"{context.Request.Method} {context.Request.Path}")
            };

            if (exception is IErrors customEx)
            {
                context.Response.StatusCode = customEx.StatusCode;

                errorResponse.statusCode = customEx.StatusCode;
                errorResponse.error = customEx.Name;
                errorResponse.message = customEx.Message;
                errorResponse.details = customEx.Details;
            }
            else
            {
                context.Response.StatusCode = 500;

                errorResponse.statusCode = 500;
                errorResponse.error = exception.GetType().Name;
                errorResponse.message = "An unexpected error was ocurred";
                errorResponse.details = exception.Message;

                _logger.LogError(exception.StackTrace);
            }

            if (exception.InnerException?.StackTrace != null)
            { 
                _logger.LogError(exception.InnerException.StackTrace);
            }

            context.Response.ContentType = "application/json";

            await context.Response.WriteAsJsonAsync(errorResponse);
        }
    }
}