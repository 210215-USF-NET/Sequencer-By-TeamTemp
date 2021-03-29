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
using MixerDL;
using MixerBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MixerREST
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

            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddCors(
                options =>
                {
                    options.AddDefaultPolicy(
                       builder =>
                   {
                       // when you build your frontend, set this as the angular website origin domain,
                       // you might also need to allow the third party api you're using to access your stuff
                       builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
                   }
                   );
                }
                );




            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "RevMixer",
                    Version = "v1"
                });
            });



            services.AddDbContext<MixerDBContext>(
                options =>
                options.UseNpgsql(Configuration.GetConnectionString("RevMixerDB")
                ),
                ServiceLifetime.Scoped
                );



            services.AddScoped<IMixerRepoDB, MixerRepoDB>();

            services.AddScoped<IMixerBL, MixBL>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint(/*swaggerURL: Configuration []*/"/swagger/v1/swagger.json", "RevMixer v1"));
            }




            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();
            app.UseSwagger();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
