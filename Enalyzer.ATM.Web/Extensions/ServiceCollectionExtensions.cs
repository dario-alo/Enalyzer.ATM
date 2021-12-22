using Enalyzer.ATM.Common.Settings;
using Enalyzer.ATM.Core.Interfaces.Repositories;
using Enalyzer.ATM.Core.Interfaces.Services;
using Enalyzer.ATM.Core.Services;
using Enalyzer.ATM.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Enalyzer.ATM.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        #region Configuration

        public static void AddConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));
        }

        #endregion Configuration

        #region Services

        public static void AddCashServices(this IServiceCollection services)
        {
            services.AddScoped<ICashService, CashService>();
            services.AddScoped<ICashRepository, CashRepository>();
        }

        #endregion Services
    }
}
