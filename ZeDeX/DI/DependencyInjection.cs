using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZeDeX.AppService.Partners;
using ZeDeX.Domain.Common;
using ZeDeX.Domain.Repositories;
using ZeDeX.Infrastructure.EntityFramework;
using ZeDeX.Infrastructure.EntityFramework.RepositoriePartner;

namespace ZeDeX.DI
{
    public class DependencyInjection
    {
        public static void Inject(IConfiguration configuration, IServiceCollection services)
        {
            #region database

            services.AddDbContext<ZedexContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), opt => opt.UseNetTopologySuite()));
            services.AddScoped<IUnitOfWork>(provider => (ZedexContext) provider.GetService(typeof(ZedexContext)));

            #endregion

            #region app services

            services.AddScoped<IPartnerAppService, PartnerAppService>();

            #endregion

            #region repositories

            services.AddScoped<IPartnerRepository, PartnerRepository>();

            #endregion

        }
    }
}
