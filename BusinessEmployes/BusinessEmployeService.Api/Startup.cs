using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using BusinessEmployeService.Core;
using BusinessEmployeService.Domain.Helpers;
using BusinessEmployeService.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Net.Http;
using BusinessEmployeService.Core.Services;
using BusinessEmployeService.Core.Interfaces;
using BusinessEmployeService.Domain.Repository;
using BusinessEmployeService.Domain.IRepository;

namespace BusinessEmployeService.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private static IContainer ApplicationContainer { get; set; }
        public IConfiguration JsonConfig { get; set; }
        public IConfigurationRoot ConfigurationRoot { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ConfigurationRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            JsonConfig = ConfigurationRoot;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Employess Api",
                    Description = "Employess Api"
                });

                c.CustomSchemaIds(x => x.FullName);
            });

            CreateDependencyInjection(services);

            return new AutofacServiceProvider(ApplicationContainer);
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
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(Configuration.GetSection("swaggerUrl").Value, "Employes API V1");
            });
        }

        private void CreateDependencyInjection(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            builder.Populate(services);
            var mapperConfiguration = new MapperConfiguration(configurationExpresion =>
            {
                configurationExpresion.AddProfile(new MappingProfile());
            });

            builder.RegisterInstance(new HttpClient());
            builder.Register(c => ConfigurationRoot).As<IConfigurationRoot>();
            builder.RegisterType<ConfigProvider>().As<IConfigProvider>();

            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>();

            builder.Register(componentContext => mapperConfiguration.CreateMapper()).As<IMapper>();


            //Repository
            // RegisterRepository(builder);

            ConfigService(builder, JsonConfig);
        }

        private static void ConfigService(ContainerBuilder builder, IConfiguration JsonConfig)
        {
            //builder.RegisterType<PlateService>().As<IPlateService>();

            builder.RegisterType<HttpClientAdapter>().As<IHttpClient>();
            builder.RegisterType<ConfigProvider>().As<IConfigProvider>();
            builder.RegisterType<EmployeeService>().As<IEmployeeService>();
            builder.RegisterType<EmployeeFactory>().As<IEmployeeFactory>();

            ApplicationContainer = builder.Build();
        }
    }
}
