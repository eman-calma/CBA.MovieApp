using AutoMapper;
using CBA.MovieApp.Common.Models;
using CBA.MovieApp.Core.Domain.Movies.Commands;
using CBA.MovieApp.Core.Domain.Movies.Commands.Validators;
using CBA.MovieApp.Core.Domain.Movies.Queries;
using CBA.MovieApp.Core.Helpers;
using CBA.MovieApp.Core.Mapping;
using CBA.MovieApp.Infrastructure.Cache;
using CBA.MovieApp.Infrastructure.MovieDatasource;
using CBA.MovieApp.Infrastructure.MovieDatasource.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CBA.MovieApp.Api
{
    public class Startup
    {


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials());
            });

            services.AddMvc()
            .AddFluentValidation(s =>
             {
                 s.RegisterValidatorsFromAssemblyContaining<Startup>();
             });

            services.AddMediatR(typeof(GetMoviesCommand).GetTypeInfo().Assembly);

            services.AddSingleton(typeof(IMovieDataSource), typeof(MovieDataSource));
            services.AddSingleton(typeof(ICacheData<>), typeof(CacheData<>));
            services.AddTransient(typeof(ISortHelper<>), typeof(SortHelper<>));
            services.AddTransient(typeof(IFilterHelper), typeof(FilterHelper));

            //Validators
            services.AddTransient<IValidator<AddMovieCommand>, AddMovieCommandValidator>();

            services.AddSwaggerGen();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowOrigin");

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: "../swagger/v1/swagger.json", name: "CBA Movie App Rest API");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
