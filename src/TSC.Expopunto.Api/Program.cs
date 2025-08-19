using TSC.Expopunto.Api;
using TSC.Expopunto.Application;
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

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.Run();

