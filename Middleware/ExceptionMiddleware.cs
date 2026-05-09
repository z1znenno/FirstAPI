using System.Text.Json;
using FirstAPI.Models.Responses;
using FirstAPI.Models.Exceptions;

namespace FirstAPI.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(NotFoundException ex)
            {
                await ExceptionHandlerAsync(context, 404, ex.Message);
            }
            catch (AuthorizeException ex)
            {
                await ExceptionHandlerAsync(context, 401, ex.Message);
            }
            catch(Exception ex)
            {
                await ExceptionHandlerAsync(context, 500, ex.Message);
            }
        }
        public async Task ExceptionHandlerAsync(HttpContext context, int StatusCode, string Message)
        {
            _logger.LogError($"Something went wrong: {Message}");
            context.Response.StatusCode = StatusCode;
            context.Response.ContentType = "application/json";
            ErrorResponse errorResponse = new ErrorResponse(StatusCode, Message);
            string json = JsonSerializer.Serialize(errorResponse);
            await context.Response.WriteAsync(json);
        }
    }
}