using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZeDeX.AppService.Partner;

namespace ZeDeX.DI
{
    public class DependencyInjection
    {
        public static void Inject(IConfiguration configuration, IServiceCollection services)
        {
            #region app services

            services.AddScoped<IPartnerAppService, PartnerAppService>();

            #endregion

        }
    }
}
