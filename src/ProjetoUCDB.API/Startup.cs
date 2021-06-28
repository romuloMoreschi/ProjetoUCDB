using AutoMapper;
using ProjetoUCDB.Services.DTO;
using ProjetoUCDB.CrossCutting;
using Microsoft.OpenApi.Models;
using ProjetoUCDB.Core.Entities;
using ProjetoUCDB.API.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjetoUCDB.Infrastructure.Context;
using Microsoft.Extensions.DependencyInjection;

namespace ProjetoUCDB.API
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
            ProjetoUCDBInjection.Main(services);

            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder.WithOrigins("*")
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            }); 
            
            services.AddSingleton(d => Configuration);
            services.AddDbContext<ProjetoUCDBContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:LOCALHOST"]), ServiceLifetime.Transient);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjetoUCDB.API", Version = "v1" });
            });

            #region AutoMapper

            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderDTO>().ReverseMap();
                cfg.CreateMap<CreateOrderViewModel, OrderDTO>().ReverseMap();
                cfg.CreateMap<UpdateOrderViewModel, OrderDTO>().ReverseMap();
            });

            services.AddSingleton(autoMapperConfig.CreateMapper());

            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjetoUCDB.API v1"));
            }

            app.UseRouting(); 
            
            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
