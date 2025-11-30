using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TSC.Expopunto.Application.External.ApiRestPeru;
using TSC.Expopunto.Application.External.GetTokenJwt;
using TSC.Expopunto.Application.Interfaces.Services;
using TSC.Expopunto.External.ApiRestPeru;
using TSC.Expopunto.External.GetTokenJwt;
using TSC.Expopunto.External.PDF.Services;

namespace TSC.Expopunto.External
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddExternal(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddSingleton<IGetTokenJwtService, GetTokenJwtService>();
            services.AddSingleton<IDocumentoPdfService, DocumentoPdfService>();
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                };
            });

            services.AddHttpClient<IApiRestPeruService, ApiRestPeruService>(client =>
            {
                client.BaseAddress = new Uri(configuration["ApiRestPeru:BaseUrl"]); // base URL del API Rest Perú
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                // si usas token:
                // client.DefaultRequestHeaders.Add("Authorization", $"Bearer {tu_token}");
            });

            //configuration["ApiRestPeru:BaseUrl"]

            return services;
        }
    }
}
