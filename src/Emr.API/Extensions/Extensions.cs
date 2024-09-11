using Emr.Domain.AggregatesModel.Patient;
using Emr.Infrastructure.Context;
using Emr.Infrastructure.Repositories;
using Emr.Infrastructure.UniOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Emr.API.Extensions
{
    public static class Extensions
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {
            var services = builder.Services;
            services.AddControllers();
            services.AddProblemDetails();

            // Connect Db
            services.AddDbContext<EmrContext>(options =>
            {
                var ConnectionString = builder.Configuration.GetConnectionString("icaredb");
                options.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString));
            });

            // Cấu hình JWT Authentication
            var key = Encoding.ASCII.GetBytes("your_secret_key_here23231gsdfg5fgdfgsg");
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = "localhost",
                    ValidAudience = "localhost",
                };
            });

            // Thêm dịch vụ Swagger vào DI container
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "My API",
                    Description = "A simple example ASP.NET Core Web API",
                });

                // Nếu bạn sử dụng Bearer token, thêm phần này để hỗ trợ xác thực bằng Swagger UI
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });       
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }});
            });

        }


    }
}
