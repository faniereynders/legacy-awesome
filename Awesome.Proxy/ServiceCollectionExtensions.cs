using Awesome.Proxy;
using Microsoft.AspNetCore.Rewrite;

namespace Microsoft.AspNetCore.Builder
{
    public static class ServiceCollectionExtensions
    {
        public static IApplicationBuilder UseProxy(this IApplicationBuilder builder)
        {
            var options = new RewriteOptions();
            options.Rules.Add(new ReverseProxyRule());
            builder.UseRewriter(options);

            return builder;
        }
    }
}
