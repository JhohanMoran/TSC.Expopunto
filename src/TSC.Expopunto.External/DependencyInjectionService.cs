using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.External.GetTokenJwt;
using TSC.Expopunto.Application.Interfaces.Services;
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

            return services;
        }
    }
}
