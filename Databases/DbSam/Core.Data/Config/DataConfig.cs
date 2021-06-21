using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SAM.Databases.DbSam.Core.Data.Context;

namespace SAM.Databases.DbSam.Core.Data.Config
{
    public class DataConfig<CONTEXT> : IDataConfig
        where CONTEXT : SAMContext
    {
        private DataConfig(IServiceCollection services, IConfiguration configuration)
        {
            this.services = services;
            this.configuration = configuration;
        }

        public static DataConfig<CONTEXT> Configure(IServiceCollection services, IConfiguration configuration)
        {
            var _this = new DataConfig<CONTEXT>(services, configuration);
            _this.Configure();
            return _this;
        }

        public IServiceCollection services { get; set; }

        public IConfiguration configuration { get; set; }

        public void Configure()
        {
            services.AddDbContext<CONTEXT>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentityCore<ApplicationUser>()
                    .AddEntityFrameworkStores<CONTEXT>();
        }
    }
}

