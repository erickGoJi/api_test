﻿using System.Net;
using api.test.Models.ApiResponse;
using biz.test.Services.Logger;
using Newtonsoft.Json;

namespace api.test.ExceptionHandler;

public class ExceptionHandler
{
    private readonly RequestDelegate _next;
    private readonly ILoggerManager _logger;

    public ExceptionHandler(RequestDelegate next, ILoggerManager logger)
    {
        _logger = logger;
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
            _logger.LogError($"Something went wrong: {ex}");
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var response = JsonConvert.SerializeObject(new ApiResponse<object>()
        {
            Result = null,
            Success = false,
            Message = "Internal Server Error"
        });

        return context.Response.WriteAsync(response);
    }
}