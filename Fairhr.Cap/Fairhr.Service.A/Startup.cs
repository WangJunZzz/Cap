using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fairhr.Service.A.LogicHandler;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;


namespace Fairhr.Service.A
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private const string con = "server=localhost;uid=root;pwd=password;port=3306;database=orderdb";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IProductLogicHandler, ProductLogicHandler>();
            services.AddDbContext<OrderInfoContext>(options =>
            {
                options.UseMySql(con);
            });

            services.AddCap(x =>
            {
                x.UseEntityFramework<OrderInfoContext>();
             

                x.UseRabbitMQ(cfg =>
                {
                    cfg.HostName = "120.77.176.104";
                    //cfg.Port = 5672;
                    cfg.Password = "rabbitmq";
                    cfg.UserName = "rabbitmq";
                });
                
                x.UseDashboard();
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            //app.UseCap();
            app.UseMvc();
        }
    }
}