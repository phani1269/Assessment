using AutoWrapper;
using HRMSFinal.Business;
using HRMSFinal.Business.Interfaces;
using HRMSFinal.Repository;
using HRMSFinal.Repository.Interfaces;
using HRMSFinal.Repository.Models;
using HRMSFinal.Utilities;
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

namespace HRMSFinal.API
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
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<NextTurnDBContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<Mycontext>(options => options.UseSqlServer(connectionString));


            services.AddTransient<IEmployeeBusiness, EmployeeBusiness>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();

            //Automapper
            services.AddAutoMapper(typeof(AutoMappingConfig));


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HRMSFinal.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HRMSFinal.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //CORS
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


            app.UseApiResponseAndExceptionWrapper();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
