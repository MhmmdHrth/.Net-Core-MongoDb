using BookServices.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;

namespace mongoWeb
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
            services.customeMongo(Configuration)
                    .customeSwagger()
                    .customeServices();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/books/swagger.json", "Books API");
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    static class ExtensionMethod
    {
        public static IServiceCollection customeSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("books", new OpenApiInfo
                {
                    Title = "Books Documentation",
                    Version = "v1"
                });
            });

            return services;
        }

        public static IServiceCollection customeServices(this IServiceCollection services)
        {
            services.AddScoped<IBookServices, BookService>();

            return services;
        }

        public static IServiceCollection customeMongo(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMongoClient, MongoClient>(options =>
            {
                return new MongoClient(configuration.GetConnectionString("mongoDb"));
            });

            return services;
        }
    }
}
