using AutoMapper;
using Domain;
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
using RecordConsumption.Mapping;
using RecordConsumption.Services.DoctorService;
using RecordConsumption.Services.PolyclinicService;
using RecordConsumption.Services.PracticeService;
using RecordConsumption.Services.SpecialitizationService;
using RecordConsumption.Services.TownService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecordConsumption
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
            services.AddDbContext<RecordConsumptionDbContext>(options =>
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RecordConsumptionDb;Trusted_Connection=True;"));
            services.AddControllers();

            services.AddTransient<ITownService, TownService>();
            services.AddTransient<IDoctorService, DoctorService>();
            services.AddTransient<IPolyclinicService, PolyclinicService>();
            services.AddTransient<IPracticeService, PracticeService>();
            services.AddTransient<ISpecializationService, SpecializationService>();

            services.AddSingleton(new MapperConfiguration(mc =>
             {
                 mc.AddProfile(new MappingProfile());
             }).CreateMapper());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RecordConsumption", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RecordConsumption v1"));
            }

            app.UseCors(x => x
             .AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
