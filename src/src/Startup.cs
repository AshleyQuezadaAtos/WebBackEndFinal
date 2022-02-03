using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Grpc;
using WebBackEndRepo.Remote.Grpc.Server.Services;
using WebCourseRepo.Configurations;
using WebCourseRepo.Repositories;
using WebCourseRepo.Repositories.Implementation;
using WebCourseRepo.Services;
using WebCourseRepo.Services.Implementation;
using WebStatusRepo.Services.Implementation;

namespace WebCourseRepo
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
            //Database configuration
            //Server=localhost;Database=db_upgrade;User Id=sa;Password=******;
            Console.WriteLine(Configuration.GetConnectionString("CourseConnection"));
            services.AddDbContext<EntityContext>(
                options => options.UseInMemoryDatabase("WebBackEndAPI"));
          

            //Repositories
            //----COURSES------//
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<IStatusService, StatusService>();
            //----STATUS------//
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICourseService, CourseService>();

            //Grpc Services
            services.AddGrpc();
            
            services.AddControllers();
            services.AddAutoMapper(typeof(Program));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIBackEnd", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Course API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<GrpcCoursesService>();
                //get protos
                endpoints.MapGet("protos/courses.proto", async context =>
                {
                    await context.Response.WriteAsync(File.ReadAllText("Remote/Grpc/Server/Protos/courses.proto"));
                });

                endpoints.MapControllers();
            });

            //Aquì se configura la base de datos (Iniciando migraciòn)
            MigrationRunner.Run(app);
        }
    }
}
