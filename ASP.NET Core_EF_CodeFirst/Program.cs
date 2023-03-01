using BLL.Extensions;

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

            //builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuer = true,
            //            ValidIssuer = AuthOptions.ISSUER,
            //            ValidateAudience = true,
            //            ValidAudience = AuthOptions.AUDIENCE,
            //            ValidateLifetime = true,
            //            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            //            ValidateIssuerSigningKey = true,
            //        };
            //    });
            

            // Add our services to the container.
            builder.Services.AddLocalServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            //app.Map("");
            //app.Map("");


            app.MapControllers();

            app.Run();
        }
    }
}