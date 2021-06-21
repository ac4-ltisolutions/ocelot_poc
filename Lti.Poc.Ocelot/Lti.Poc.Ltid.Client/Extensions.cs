using Microsoft.AspNetCore.Builder;

namespace Lti.Poc.Ltid.Client
{
    public static class Extensions
    {
        public static IApplicationBuilder UseLtidDebugMiddleware(this IApplicationBuilder builder, ILtidClient client)
        {
            return builder.Map("/lti-debug", o => o.UseMiddleware<DebugMiddleware>(client));
        }
    }
}
