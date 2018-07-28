using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Bookshop.CrossCutting.IoC;
using Bookshop.Service.WebAPI.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bookshop.Service.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        IServiceProvider serviceProvider;

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc();
            services.AddAutoMapper(mapper => mapper.AddProfile(new BookMapper()));

            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "Bookshop API",
                    Version = "v1",
                    Description = "This API handles all allowed bookshop operations."
                });
            });

            ContainerBuilder container = new ContainerBuilder();
            container.Populate(services);

            container.RegisterModule(new CustomServiceModule(
                Configuration.GetSection("MongoDB").GetValue<string>("ConnectionString"),
                Configuration.GetSection("MongoDB").GetValue<string>("Database")));

            serviceProvider = new AutofacServiceProvider(container.Build());

            return serviceProvider;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });

            app.UseMvc();

            app.UseSwagger(c => {
                c.PreSerializeFilters.Add((swagger, httpReq) =>
                {
                    swagger.Host = Configuration.GetSection("Server").GetValue<string>("Header");
                    swagger.BasePath = Configuration.GetSection("Server").GetValue<string>("BasePath");
                });
            })
           .UseSwaggerUI(c =>
           {
               c.SwaggerEndpoint("v1/swagger.json", "My API V1");
           });
        }
    }
}
