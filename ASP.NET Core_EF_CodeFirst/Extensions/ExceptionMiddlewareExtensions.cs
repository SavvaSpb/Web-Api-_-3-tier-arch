using ASP.NET_Core_EF_CodeFirst.Middlewares.CustomExceptionMiddleware;

namespace ASP.NET_Core_EF_CodeFirst.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
