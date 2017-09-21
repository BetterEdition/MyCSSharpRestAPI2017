using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CustomerAppBLL;
using CustomerAppBLL.BusinessObjects;

namespace CustomerRestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                var facade = new BLLFacade();

                var address = facade.AddressService.Create(
                    new AddressBO()
                    {
                        City = "Esbjerg",
                        Street = "Ragerikkenogen",
                        Number = "63T"
                    });

                var cust = facade.CustomerService.Create(
                    new CustomerBO() {
                        FirstName = "Tenna",
                        LastName = "Jenna",
                        Addresses = new List<AddressBO> {address }

                    });
                facade.CustomerService.Create(
                    new CustomerBO()
                    {
                        FirstName = "Tage",
                        LastName = "Frans",
                        Addresses = new List<AddressBO> { address }

                    });
                for (int i = 0; i < 10000; i++)
                {
                    facade.OrderService.Create(
                        new OrderBO()
                        {
                            DeliveryDate = DateTime.Now.AddMonths(1),
                            OrderDate = DateTime.Now.AddMonths(-1),
                            CustomerId = cust.Id

                        }
                    );
                }
               
            }

            app.UseMvc();
        }
    }
}
