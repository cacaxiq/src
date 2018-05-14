﻿using AutoMapper;
using Base.ExternalData.Context;
using Base.IoC;
using Base.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Base.WebApi
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
            services.AddDbContext<BaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            NativeInjectorBootStrapper.RegisterServices(services);

            services.AddTokenSecurity(Configuration);

            services.AddMvc();

            services.AddSwaggerDocumentation();

            services.AddAutoMapper();

            //Add Mediatr services.
            services.AddMediatR(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerDocumentation();
            }
            else
            {
                app.UseSwaggerDocumentationAzure();
            }

            app.UseMvc();
        }
    }
}
