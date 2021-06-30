using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SAM.Core.AuthConfig;
using SAM.Core.SwaggerConfig;
using SAM.Databases.DbSam.Core.Data.Config;
using SAM.Functions.ControlGift.Business;
using System.Security.Principal;

namespace SAM.Functions.ControlGifts.MicroService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<IPrincipal>(provider => provider.GetService<IHttpContextAccessor>().HttpContext.User);
            services.AddTransient<IControlGiftsBusiness, ControlGiftsBusiness>();
            services.AddTransient<IReportsControlGiftBusiness, ReportsControlGiftBusiness>();

            DataConfig<ControlGiftsContext>.Configure(services, Configuration);
            AuthConfig.Configure(services, Configuration);
            SwaggerConfig.Configure(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{Configuration.GetSection("SwaggerConfig")["Title"]} {Configuration.GetSection("SwaggerConfig")["Version"]}"));
            }

            app.UseRouting();
            app.UseHttpsRedirection();

            app.UseCors("CorsDevPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
