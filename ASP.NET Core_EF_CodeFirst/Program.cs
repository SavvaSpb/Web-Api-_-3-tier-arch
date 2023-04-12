using ASP.NET_Core_EF_CodeFirst.Middlewares.CustomExceptionMiddleware;
using BLL.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ASP.NET_Core_EF_CodeFirst.Extensions.MappingExtensions;
using ASP.NET_Core_EF_CodeFirst.Extensions;
using BLL.AuthHelpers;

namespace ASP.NET_Core_EF_CodeFirst
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAuthorization();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey= false,
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(builder.Configuration["Jwt:Key"])
                };
            });

            // Add our services to the container.
            builder.Services.AddLocalServices();

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.ConfigureCustomExceptionMiddleware();

            app.MapControllers();

            app.Run();

        }
    }
}
