using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZeDeX.AppService.Partner;
using ZeDeX.Domain.Common;
using ZeDeX.Infrastructure.EntityFramework;

namespace ZeDeX.DI
{
    public class DependencyInjection
    {
        public static void Inject(IConfiguration configuration, IServiceCollection services)
        {
            #region database

            services.AddDbContext<ZedexContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork>(provider => (ZedexContext) provider.GetService(typeof(ZedexContext)));

            #endregion

            #region app services

            services.AddScoped<IPartnerAppService, PartnerAppService>();

            #endregion

        }
    }
}
