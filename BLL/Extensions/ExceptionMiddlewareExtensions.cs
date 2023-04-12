//using Microsoft.AspNetCore.Builder;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BLL.Extensions
//{

//    public static class ExceptionMiddlewareExtensions1
//    {

//        public static void ConfigureCustomExceptionMiddleware1(this IApplicationBuilder app)
//        {
//            app.UseMiddleware<ExceptionMiddleware>();
//        }

//        //public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerManager logger)
//        //{
//        //    app.UseExceptionHandler(appError =>
//        //    {
//        //        appError.Run(async context =>
//        //        {
//        //            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
//        //            context.Response.ContentType = "application/json";
//        //            var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
//        //            if (contextFeature != null)
//        //            {
//        //                logger.LogError($"Something went wrong: {contextFeature.Error}");
//        //                await context.Response.WriteAsync(new ErrorDetails()
//        //                {
//        //                    StatusCode = context.Response.StatusCode,
//        //                    Message = "Internal Server Error."
//        //                }.ToString());
//        //            }
//        //        });
//        //    });
//        //}
//    }
//}
