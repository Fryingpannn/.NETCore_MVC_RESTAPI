using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Commander.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Commander.Models;
using Microsoft.OpenApi.Models;

namespace Commander
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
            //for controllers and PATCH request
            services.AddControllers().AddNewtonsoftJson(s => {
             s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            //Mock repo dependency injection
            /*services.AddScoped<ICommanderRepo, MockCommanderRepo>();*/

            //Registering service container: whenever ICommanderRepo is asked, give SqlCommanderRepo
            //to change implementation, all you have to do is change second parameter!
            services.AddScoped<ICommanderRepo, SqlCommanderRepo>();

            //Configure our DB context class for use within rest of app; dependency injection support, adds dbcontext to service container
            services.AddDbContext<CommanderContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("CommanderConnection")));

            //makes automapper available through dependency injection to the rest of our app (for DTOs)
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Swagger UI
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Matthew's Commander API", Version = "v1" });
            });
            services.AddSwaggerGenNewtonsoftSupport();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // if (env.IsDevelopment())
            // {
            //     app.UseDeveloperExceptionPage();
            // }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix= "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Commander API V1");
            });

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
