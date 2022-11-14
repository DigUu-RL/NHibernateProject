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

	public async Task InvokeAsync(HttpContext context)
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

	private static async Task HandleExceptionAsync(HttpContext context, Exception ex, HttpStatusCode statusCode = default)
	{
		if (ex is not GlobalException)
			statusCode = HttpStatusCode.InternalServerError;

		context.Response.ContentType = "application/json";
		context.Response.StatusCode = (int) statusCode;

		string result = JsonConvert.SerializeObject(new
		{
			statusCode,
			statusName = statusCode.ToString(),
			errorMessage = ex.Message,
			innerException = ex.InnerException?.Message
		});

		await context.Response.WriteAsync(result);
	}
}
