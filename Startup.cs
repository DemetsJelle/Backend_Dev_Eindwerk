using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_Dev_Eindwerk.Configuration;
using Backend_Dev_Eindwerk.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Backend_Dev_Eindwerk.Repositories;
using Backend_Dev_Eindwerk.Services;
using AutoMapper;

namespace Backend_Dev_Eindwerk
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

            services.AddAutoMapper(typeof(Startup));  

            services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));

            services.AddDbContext<EindwerkContext>();

            services.AddControllers();

            services.AddTransient<IEindwerkContext, EindwerkContext>();

            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<ILeagueRepository, LeagueRepository>();
            services.AddTransient<ISponsorRepository, SponsorRepository>();
 
            services.AddTransient<IPlayerService, PlayerService>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Backend_Dev_Eindwerk", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Backend_Dev_Eindwerk v1"));
            }

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
