using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NHibernateProject.Infra.Middleware.Exceptions;
using System.Net;

namespace NHibernateProject.Infra.Middleware;

public class ErrorMiddleware
{
	private readonly RequestDelegate request;

	public ErrorMiddleware(RequestDelegate request)
	{
		this.request = request;
	}

	public async Task Invoke(HttpContext context)
	{
		try
		{
			await request(context);
		}
		catch (GlobalException ex)
		{
			await HandleExceptionAsync(context, ex, ex.StatusCode);
		}
		catch (Exception ex)
		{
			await HandleExceptionAsync(context, ex);
		}
	}

	private static Task HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode statusCode = default)
	{
		if (exception is not GlobalException)
			statusCode = HttpStatusCode.InternalServerError;

		context.Response.ContentType = "application/json";
		context.Response.StatusCode = (int) statusCode;

		string result = JsonConvert.SerializeObject(new
		{
			statusCode,
			statusName = statusCode.ToString(),
			errorMessage = exception.Message
		});

		return context.Response.WriteAsync(result);
	}
}
