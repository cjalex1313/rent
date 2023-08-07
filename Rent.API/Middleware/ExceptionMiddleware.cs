using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Rent.API.Models.Base;
using Rent.Domain.Exceptions;

namespace Rent.API.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        if (exception is BaseException)
        {
            var baseEx = (BaseException)exception;
            context.Response.StatusCode = baseEx.StatusCode;
            var response = new BaseResponse()
            {
                Succeeded = false,
                Error = baseEx.ErrorMessage,
                Errors = baseEx.Errors
            };
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
        else
        {
            await context.Response.WriteAsync(JsonSerializer.Serialize(new
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            }));
        }
    }
}