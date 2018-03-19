using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
namespace Awesome.Proxy
{
    public class ReverseProxyRule : IRule
    {


        public void ApplyRule(RewriteContext context)
        {

            var config = context
                .HttpContext
                .RequestServices
                .GetService<IConfiguration>();

            var proxies = config.GetSection("Proxies").Get<ProxyConfiguration[]>();

            foreach (var proxy in proxies)
            {
                var request = context.HttpContext.Request;
                if (proxy.Rules != null)
                {
                    foreach (var path in proxy.Rules)
                    {
                        var regex = new Regex(path, RegexOptions.IgnoreCase);
                        if (regex.IsMatch(request.Path))
                        {
                            var uri = new Uri($"{proxy.DestinationUrl}/{request.Path}{request.QueryString}");
                            var req = context.HttpContext.CreateProxyHttpRequest(uri);

                            var client = new HttpClient();
                            var response = client.SendAsync(req).Result;
                            context.HttpContext.CopyProxyHttpResponse(response).Wait();

                            context.Result = RuleResult.EndResponse; 
                            return;

                        }
                    }
                }
            }          
            
            context.Result = RuleResult.ContinueRules;
        }
    }
}
