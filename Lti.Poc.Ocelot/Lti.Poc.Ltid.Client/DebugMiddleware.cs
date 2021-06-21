using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace Lti.Poc.Ltid.Client
{
    public class DebugMiddleware : IMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly PathString _path;
        private readonly ILtidClient _client;

        public DebugMiddleware(RequestDelegate next, PathString path, ILtidClient client)
        {
            _next = next;
            _path = path;
            _client = client;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (!context.Request.Path.StartsWithSegments(_path))
            {
                await _next.Invoke(context);
            }

            if (await _client.ValidateSession(context)) await _next.Invoke(context);


            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
    }
}
