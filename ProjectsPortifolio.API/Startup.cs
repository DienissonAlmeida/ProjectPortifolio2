using AutoMapper;
using ProjectsPortifolio.API.Extensions;
using ProjectsPortifolio.Application.Features.Projects.Commands;
using ProjectsPortifolio.Data.Context;
using ProjectsPortifolio.Domain;
using ProjectsPortifolio.Domain.Features.Projects;
using ProjectsPortifolio.Infra.Data.Features;
using ProjectsPortifolio.Infra.Data.Features.Projects;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Reflection;

namespace ProjectsPortifolio.API
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
            services.AddDbContext<ProjectsPortifolioDbContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("ProjectsPortifolioDbContext"));
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).
                AddJsonOptions(
                options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.Formatting = Formatting.Indented;
                });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(ProjectRegisterCommand).GetTypeInfo().Assembly);

            AddScoped(services);

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProjectRegisterCommand, Project>();


                cfg.CreateMap<ProjectUpdateCommand, Project>();
                cfg.CreateMap<PersonCommand, Person>();

            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

        private static void AddScoped(IServiceCollection services)
        {
            services.AddScoped<IProjectRepository, ProjectReservationRepository>();
            services.AddScoped<IRepositoryBase<Project>, RepositoryBase<Project>>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseMvc();

        }
    }
}
