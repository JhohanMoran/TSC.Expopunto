using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Security;

namespace TSC.Expopunto.Application.Exceptions
{
    public class ExceptionManager : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            int statusCode;
            string message = exception.Message;

            switch (exception)
            {
                case ValidationException validationEx:
                    statusCode = StatusCodes.Status400BadRequest;
                    message = "Errores de validación";
                    context.Result = new BadRequestObjectResult(new
                    {
                        statusCode,
                        message,
                        errors = validationEx.Errors
                            .GroupBy(e => e.PropertyName)
                            .ToDictionary(
                                g => g.Key,
                                g => g.Select(e => e.ErrorMessage).ToArray()
                            )
                    });
                    break;

                case ArgumentException:
                case InvalidOperationException:
                    statusCode = StatusCodes.Status400BadRequest;
                    break;

                case KeyNotFoundException:
                    statusCode = StatusCodes.Status404NotFound;
                    break;

                case UnauthorizedAccessException:
                    statusCode = StatusCodes.Status401Unauthorized;
                    break;

                case SecurityException:
                    statusCode = StatusCodes.Status403Forbidden;
                    break;

                case TimeoutException:
                case TaskCanceledException:
                    statusCode = StatusCodes.Status408RequestTimeout;
                    break;

                case HttpRequestException:
                    statusCode = StatusCodes.Status502BadGateway;
                    break;

                case IOException:
                case DbUpdateException:
                case SqlException:
                    statusCode = StatusCodes.Status500InternalServerError;
                    break;

                default:
                    statusCode = StatusCodes.Status500InternalServerError;
                    break;
            }

            // Si no era ValidationException, devolvemos un objeto estándar
            if (!(exception is ValidationException))
            {
                context.Result = new ObjectResult(new
                {
                    statusCode,
                    message
                });
            }

            context.HttpContext.Response.StatusCode = statusCode;
        }

    }
}
