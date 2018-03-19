using Awesome.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Awesome
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = configuration["Db"];
            services
                .AddSingleton<IOrdersRepository,OrdersRepository>(s=>new OrdersRepository(connectionString))
                .AddSingleton<ICustomersRepository, CustomersRepository>(s => new CustomersRepository(connectionString))
                .AddMvc()
                .AddRazorOptions(o => o.ViewLocationFormats.Add("/Pages/{1}/{0}.cshtml"))
                .AddRazorPagesOptions(o => o.Conventions.AddPageRoute("/Default/Index", ""));         
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
