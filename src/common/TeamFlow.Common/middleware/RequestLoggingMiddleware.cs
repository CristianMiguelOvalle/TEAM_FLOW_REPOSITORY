using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TeamFlow.Common.middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;

        }

        public async Task InvokeAsync(HttpContext context)
        {
            var method = context.Request.Method;
            var route = context.Request.Path;
            Stopwatch sw = new Stopwatch();
            sw.Start();

            //Console.WriteLine($"method: {method} - route {route}");

            await _next.Invoke(context);

            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            var statusCode = context.Response.StatusCode;
            

            //Console.WriteLine($"time: {elapsedTime}, status code: {statusCode}");

        }
    }
}
