using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.OpenApi.Models;
using MoverCandidate.Domain.Inventory.Entities;
using MoverCandidate.Domain.Inventory.Data;
using MoverCandidate.Domain.Inventory.Api;
using System.Reflection;

namespace MoverCandidateTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<InventoryDbContext>(opt => opt.UseInMemoryDatabase("in_memory"));
            services.AddScoped<InventoryItemsRepository>();

            var useCaseTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type => typeof(IUseCase).IsAssignableFrom(type) 
                                && !type.IsInterface 
                                && !type.IsAbstract)
                .ToList();
            foreach (var useCaseType in useCaseTypes)
                services.AddScoped(useCaseType);

            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Implement Swagger UI",
                    Description = "A simple example to Implement Swagger UI",
                });
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Showing API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
