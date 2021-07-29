using BLL.FurnitureCategoryService;
using BLL.FurnitureImagesService;
using BLL.FurnitureServices;
using Common.Settings;
using DataAccessLayer.Infrastructure;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using FurnitureTask.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureTask
{

   
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Configuration.GetSection("FileStorageSettings").Bind(new FileStorageSettings());
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<StorageDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetSection("ConnectionStrings:DefaultConnection").Value);
            });
            services.AddScoped<IDbContext, StorageDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IFurnitureCategoryRepository, FurnitureCategoryRepository>();
            services.AddScoped<IFurnitureRepository, FurnitureRepository>();
            services.AddScoped<IFurnitureImagesRepository, FurnitureImagesRepository>();

            services.AddScoped<IFurnitureCategoryService, FurnitureCategoryService>();
            services.AddScoped<IFurnitureService, FurnitureService>();
            services.AddScoped<IFurnitureImageService, FurnitureImageService>();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    );
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FurnitureTask", Version = "v1" });
            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDbContext dbContext)
        {
            dbContext.EnsureCreated();  
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FurnitureTask v1"));
            }
            app.UseMiddleware<ExceptionMiddleware>();
            //dapp.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
