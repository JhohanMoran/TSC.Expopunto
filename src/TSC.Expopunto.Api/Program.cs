using TSC.Expopunto.Api;
using TSC.Expopunto.Application;
using TSC.Expopunto.Application.Exceptions;
using TSC.Expopunto.Application.Interfaces.GuiaEntrada;
using TSC.Expopunto.Common;
using TSC.Expopunto.External;
using TSC.Expopunto.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddWebApi()
    .AddCommon()
    .AddApplication()
    .AddExternal(builder.Configuration)
    .AddPersistence(builder.Configuration);



builder.Services.AddControllers(options =>
{
    options.Filters.Add<ExceptionManager>();
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.WithOrigins(
                    "http://localhost:4200",
                    "http://172.16.87.21:9090"
                )
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseCors("AllowAngular");
app.MapControllers();
app.Run();

