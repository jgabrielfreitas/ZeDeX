using System.Collections.Generic;
using System.Threading.Tasks;
using ZeDeX.Domain.Common.Entities;
using ZeDeX.Domain.Repositories.Operation;

namespace ZeDeX.Domain.Repositories
{
    public interface IPartnerRepository : ISelect<Partner>, IInsert<Partner>
    {
        Task<IEnumerable<Partner>> GetNearest(double lat, double @long);
    }
}
