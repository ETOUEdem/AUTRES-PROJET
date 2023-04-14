using FeedBackService.Core.Exceptionne;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace FeedBackService.Api.Middlewares
{

    public static class HttpStatusCodeExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseHttpCodeAndLogMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<httpCodeAndLogMiddleware>();
        }

    }

    public class httpCodeAndLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<httpCodeAndLogMiddleware> _logger;

        public httpCodeAndLogMiddleware(RequestDelegate next, ILogger<httpCodeAndLogMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext == null)
            {
                return;
            }
            try
            {
                var response = httpContext.Response;
                response.ContentType = "application/json";

            }
            catch (Exception exception)
            {
                switch (exception)
                {
                    case ApiException e:
                        httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        await WriteAndLogResponseAsync(exception, httpContext, HttpStatusCode.BadRequest, LogLevel.Error, "BadRequest Exception" + e.Message);
                        break;
                    case NotFoundException e2:
                        await WriteAndLogResponseAsync(exception, httpContext, HttpStatusCode.NotFound, LogLevel.Error, "Not Found !" + e2.Message);
                        break;
                    case ValidationException e3:
                        await WriteAndLogResponseAsync(exception, httpContext, HttpStatusCode.UnprocessableEntity, LogLevel.Error, "Validation Exception" + e3.Message);
                        break;
                    case AuthenticationException e3:
                        await WriteAndLogResponseAsync(exception, httpContext, HttpStatusCode.UnprocessableEntity, LogLevel.Error, "Validation Exception" + e3.Message);
                        break;
                    default:
                        await WriteAndLogResponseAsync(exception, httpContext, HttpStatusCode.InternalServerError, LogLevel.Error, "Server error");
                        break;

                }

            }
        }

        private async Task WriteAndLogResponseAsync(
            Exception exception,
            HttpContext httpContext,
            HttpStatusCode httpStatusCode,
            LogLevel logLevel,
            string alternateMessage = null
            )
        {
            string requestBody = string.Empty;
            if (httpContext.Request.Body.CanSeek)
            {
                httpContext.Request.Body.Seek(0, System.IO.SeekOrigin.Begin);
                using (var sr = new System.IO.StreamReader(httpContext.Request.Body))
                {
                    requestBody = JsonConvert.SerializeObject(sr.ReadToEndAsync());
                }
            }
            StringValues authorization;
            httpContext.Request.Headers.TryGetValue("Authorization", out authorization);
            var customeDetails = new StringBuilder();
            customeDetails
                .AppendFormat("\n Service URL :").Append(httpContext.Request.Path.ToString())
                .AppendFormat("\n Request Method :").Append(httpContext.Request?.Method)
                .AppendFormat("\n Request Body :").Append(requestBody)
                .AppendFormat("\n Authorization :").Append(authorization)
                .AppendFormat("\n Content-Type :").Append(httpContext.Request.Headers["Content-Type"].ToString())
                .AppendFormat("\n Cookie :").Append(httpContext.Request.Headers["Cookie"].ToString())
                .AppendFormat("\n Host :").Append(httpContext.Request.Headers["Host"].ToString())
                .AppendFormat("\n Referer :").Append(httpContext.Request.Headers["Referer"].ToString())
                .AppendFormat("\n Origin :").Append(httpContext.Request.Headers["Origin"].ToString())
                .AppendFormat("\n User-Agent :").Append(httpContext.Request.Headers["User-Agent"].ToString())
                .AppendFormat("\n Error Message :").Append(exception.Message);
            _logger.Log(logLevel, exception, customeDetails.ToString());
            if (httpContext.Response.HasStarted)
            {
                _logger.LogError("The response has already started , the http status code middleware will not be executed");
                return;
            }

            string responseMessage = JsonConvert.SerializeObject(
                new
                {
                    Message = string.IsNullOrWhiteSpace(exception.Message) ? alternateMessage : exception.Message,
                });
            httpContext.Response.Clear();
            httpContext.Response.ContentType = System.Net.Mime.MediaTypeNames.Application.Json;
            httpContext.Response.StatusCode = (int)httpStatusCode;
            await httpContext.Response.WriteAsync(responseMessage, Encoding.UTF8);

        }

    }
}
