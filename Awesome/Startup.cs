using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Awesome
{
    public class Startup
    {
       
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddMvc()

                .AddRazorOptions(o =>
                {
                    o.ViewLocationFormats.Add("/Pages/{1}/{0}.cshtml");

                })

                .AddRazorPagesOptions(o =>
                {

                    o.Conventions.AddPageRoute("/Default/Index", "");
                });


         
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseProxy();

            app.UseMvcWithDefaultRoute();
        }
    }
    
}
