using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using patientimaging_api.Services;
using Microsoft.AspNetCore.SignalR;
using patientimaging_api.Hubs;

namespace patientimaging_api
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
            IMvcBuilder mvcBuilder = services.AddMvc(options => options.EnableEndpointRouting = false);
            IServiceCollection serviceCollection = services.AddDbContext<Persistence.MainDbContext>(contextOptions =>
            {
                DbContextOptionsBuilder dbContextOptionsBuilder = contextOptions.UseSqlServer(Configuration.GetValue<string>(key: "ConnectionString"));
            });
            IServiceCollection serviceCollection1 = services.AddTransient<IPatientService, PatientService>();
            ISignalRServerBuilder signalRServerBuilder = services.AddSignalR();

            IServiceCollection serviceCollection2 = services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder corsPolicyBuilder = builder.AllowAnyMethod().AllowAnyHeader().AllowCredentials().WithOrigins("http://localhost:4200");
                //builder
                //.AllowAnyMethod()
                //.AllowAnyHeader()
                //.AllowCredentials()
                //.WithOrigins("http://localhost:4200");
            }));

            // services.AddTransient<IPatientService, PatientService>();
            // services.AddControllers();
            // services.AddSignalR();

        }

        public static void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                IApplicationBuilder applicationBuilder1 = app.UseDeveloperExceptionPage();
            }

            IApplicationBuilder applicationBuilder = app.UseCors("CorsPolicy");

            IApplicationBuilder applicationBuilder2 = app.UseMvc();

            IApplicationBuilder applicationBuilder3 = app.UseRouting();

            IApplicationBuilder applicationBuilder4 = app.UseEndpoints(endpoints =>
            {
                HubEndpointConventionBuilder hubEndpointConventionBuilder = endpoints.MapHub<PatientHub>("/patientHub");
            });
        }
    }
}