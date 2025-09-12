using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TSC.Expopunto.Application.Features;

namespace TSC.Expopunto.Application.Exceptions
{
    public class ExceptionManager : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException validationEx)
            {
                // 🔹 Errores de validación (FluentValidation)
                var errors = validationEx.Errors
                    .GroupBy(e => e.PropertyName)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Select(e => e.ErrorMessage).ToArray()
                    );

                context.Result = new BadRequestObjectResult(new
                {
                    statusCode = StatusCodes.Status400BadRequest,
                    message = "Errores de validación",
                    errors
                });

                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
            else
            {
                // 🔹 Otras excepciones (500)
                context.Result = new ObjectResult(new
                {
                    statusCode = StatusCodes.Status500InternalServerError,
                    message = context.Exception.Message
                });

                context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            }
        }
    }
}
