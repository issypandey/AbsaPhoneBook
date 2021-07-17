using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Phonebook.Queries.GetPhonebookContactListQuery;
using MediatR;
using System.Reflection;
using Core.Interfaces.Services;
using AbsaPhoneBook.Services;
using Microsoft.AspNetCore.Http;
using Repository;
using Core.Interfaces.Repo;
using PhonebookDB.EF;
using AbsaPhoneBook.Common;
using Microsoft.AspNetCore.Server.IISIntegration;

namespace AbsaPhoneBook
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

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            services.AddPersistence(Configuration);
            services.AddControllers();

            services.AddMediatR(typeof(GetPhonebookEntryListQuery.GetPhonebookEntryListQueryHandler).GetTypeInfo().Assembly);

            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IPhonebookRepo, PhonebookRepo>();

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCustomExceptionHandler();
            //app.UseHttpsRedirection();
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
           // app.UseCors(
           //    options => options.WithOrigins("http://localhost:4200").AllowAnyMethod()
           //);
            app.UseCors("CorsPolicy");
            //app.UseMvc();
            app.UseRouting();


            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
