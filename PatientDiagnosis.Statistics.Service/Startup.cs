using System.Linq;
using System.Reflection;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PatientDiagnosis.Common.Architecture;
using PatientDiagnosis.Common.Configuration;
using PatientDiagnosis.Examinations.Service.Models;

namespace PatientDiagnosis.Examinations.Service
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
            services.AddControllers()
                .AddNewtonsoftJson();
            services.AddEntityFrameworkNpgsql().AddDbContext<ExaminationDbContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("ExaminationConnection")));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Examinations", Version = "v1" });
            });
            services.AddHttpClient();

            services.AddOptions();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var runtime = DependencyContext.Default.Target.Runtime;
            var assemblyNames = DependencyContext.Default.GetRuntimeAssemblyNames(runtime);
            var assemblies = assemblyNames
                .Where(name => name.Name.StartsWith("PatientDiagnosis.Statistics") || name.Name.Contains("Common"))
                .Distinct()
                .Select(Assembly.Load)
                .ToArray();

            builder.RegisterAssemblyModules(assemblies);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Examinations api v1");
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
