using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;

namespace dotnetmvcapp.MiddleWare
{
    public class AuthMiddleWare
    {
        private readonly RequestDelegate _next;

        public AuthMiddleWare(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Session.GetString("AuthToken");
            if (token == null)
            {
                var path = context.Request.Path;
                if(string.IsNullOrWhiteSpace(path) || path.Value.Equals("/") || path.StartsWithSegments("/Home/Register"))
                {
                    await _next.Invoke(context);
                }
                else
                {
                    var redirectUrl =
                    UriHelper
                        .BuildAbsolute("http",
                        context.Request.Host,
                        context.Request.PathBase);
                    context.Response.Redirect(redirectUrl);
                }
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
