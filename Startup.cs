using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PoWeeU_Backend.Data;
using GraphQL.Server;
using PoWeeU_Backend.Repository;
using Microsoft.EntityFrameworkCore;
using PoWeeU_Backend.Data.GraphQL;

namespace PoWeeU_Backend
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
            services.AddControllers();
            services.AddDbContext<PowerUdbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:PowerU"]));
            services.AddScoped<adminRepository>();
            services.AddScoped<CustomerRepository>();
            services.AddScoped<ProviderRepository>();
            services.AddScoped<BatteryRepository>();
            services.AddScoped<TransactionRepository>();

            services.AddScoped<IServiceProvider>(s => new GraphQL.FuncServiceProvider(s.GetRequiredService));
            services.AddScoped<PoWerUSchema>();

            services.AddGraphQL().AddSystemTextJson().AddGraphTypes(ServiceLifetime.Scoped);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors(builder =>
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseGraphQL<PoWerUSchema>();
            app.UseGraphQLPlayground();
        }
    }
}
