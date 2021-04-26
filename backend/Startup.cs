using GFT.Restaurant.Order.Borders.Adapters;
using GFT.Restaurant.Order.Borders.Adapters.Interface;
using GFT.Restaurant.Order.Borders.Repositories;
using GFT.Restaurant.Order.Borders.Services;
using GFT.Restaurant.Order.Borders.UseCase;
using GFT.Restaurant.Order.Borders.Validators;
using GFT.Restaurant.Order.Borders.Validators.Interfaces;
using GFT.Restaurant.Order.Repositories;
using GFT.Restaurant.Order.Repositories.Context;
using GFT.Restaurant.Order.Services.MealList;
using GFT.Restaurant.Order.UseCase;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace backend
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
            services.AddDbContext<RestaurantContext>(opt => opt.UseInMemoryDatabase("restaurante"));

            services.AddScoped<IGetListOrders, GetListOrders>();
            services.AddScoped<IAddOrder, AddOrder>();
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<INightMeal, NightMeal>();
            services.AddScoped<IMorningMeal, MorningMeal>();
            services.AddTransient<IAddOrderValidator, AddOrderValidator>();
            services.AddTransient<IAddOrderAdapter, AddOrderAdapter>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "backend", Version = "v1" });
            });
            services.AddCors(options =>
            {
                options.AddPolicy("Cors", builder=>builder
                                            .AllowAnyOrigin()
                                            .AllowAnyMethod()
                                            .AllowAnyHeader()
                                            );
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "backend v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors("Cors");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
           
        }
    }
}
