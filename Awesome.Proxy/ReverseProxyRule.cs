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

            var rules = config.GetSection("Proxy:Rules").Get<string[]>();
            var destinationUrl = config["Proxy:DestinationUrl"];

            var request = context.HttpContext.Request;
            //var host = request.Host;

            foreach (var path in rules)
            {
                var regex = new Regex(path, RegexOptions.IgnoreCase);
                if (regex.IsMatch(request.Path))
                {
                    var uri = new Uri($"{destinationUrl}/{request.Path}{request.QueryString}");
                    var req = context.HttpContext.CreateProxyHttpRequest(uri);

                    var client = new HttpClient();
                    var result = client.SendAsync(req).Result.Content.ReadAsStringAsync().Result;
                    context.HttpContext.Response.WriteAsync(result);
                    context.Result = RuleResult.EndResponse; // Do not continue processing the request        
                    return;

                }
            }
            context.Result = RuleResult.ContinueRules;


            //    context.StaticFileProvider.



        }
    }
}
