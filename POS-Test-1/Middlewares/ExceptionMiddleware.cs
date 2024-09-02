//using Microsoft.AspNetCore.Http;
//using System;
//using System.Threading.Tasks;

//namespace POS_Test_1.Helpers
//{
//    public class ExceptionMiddleware
//    {
//        private readonly RequestDelegate _next;

//        public ExceptionMiddleware(RequestDelegate next)
//        {
//            _next = next;
//        }

//        public async Task InvokeAsync(HttpContext context)
//        {
//            try
//            {
//                await _next(context);
//            }
//            catch (Exception ex)
//            {
//                // Handle exception
//                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
//                await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
//            }
//        }
//    }
//}
