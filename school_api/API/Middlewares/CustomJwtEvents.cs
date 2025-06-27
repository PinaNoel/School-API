
using Microsoft.AspNetCore.Authentication.JwtBearer;
using school_api.API.DTOs;


namespace school_api.API.Middlewares
{
    public class CustomJwtEvents : JwtBearerEvents
    {
        public override Task AuthenticationFailed(AuthenticationFailedContext context)
        {
            context.NoResult();
            context.Response.StatusCode = 401;
            context.Response.ContentType = "application/json";

            ErrorDTO errorDTO = new ErrorDTO
            {
                statusCode = context.Response.StatusCode,
                path = $"{context.Request.Method} {context.Request.Path}",
                error = "Authentication Failed",
                message = "Invalid or expired token",
            };

            return context.Response.WriteAsJsonAsync(errorDTO);
        }


        public override Task Challenge(JwtBearerChallengeContext context)
        {
            context.HandleResponse();
            context.Response.StatusCode = 401;
            context.Response.ContentType = "application/json";

            ErrorDTO errorDTO = new ErrorDTO
            {
                statusCode = context.Response.StatusCode,
                path = $"{context.Request.Method} {context.Request.Path}",
                error = "Challenge",
                message = "Missing or unauthorized token",
            };

            return context.Response.WriteAsJsonAsync(errorDTO);
        }


        public override Task Forbidden(ForbiddenContext context)
        {
            context.NoResult();
            context.Response.StatusCode = 403;
            context.Response.ContentType = "application/json";

            ErrorDTO errorDTO = new ErrorDTO
            {
                statusCode = context.Response.StatusCode,
                path = $"{context.Request.Method} {context.Request.Path}",
                error = "Forbidden",
                message = "User does not have sufficient permissions",
            };

            return context.Response.WriteAsJsonAsync(errorDTO);
        }
    }   
}