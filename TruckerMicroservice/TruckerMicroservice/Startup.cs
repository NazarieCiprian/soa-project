using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TruckerMicroservice.Application.Queries;
using TruckerMicroservice.Domain.Repository;
using TruckerMicroservice.Infrastructure;
using TruckerMicroservice.Infrastructure.Repository;

namespace TruckerMicroservice
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();
            services.AddDbContext<TruckerDbContext>(options => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test"));
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<ITruckerRepository, TruckerRepository>();
            services.AddScoped<IFreightsRegisterRepository, FreightRegisterRepository>();

            services.AddScoped<ITruckerQueries, TruckerQueries>();
            services.AddScoped<IFreightRegistersQueries, FreightRegistersQueries>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<GreeterService>();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
        }
    }
}
