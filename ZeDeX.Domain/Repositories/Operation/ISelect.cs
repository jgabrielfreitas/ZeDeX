using System.Linq;
using ZeDeX.Domain.Common.Entities;

namespace ZeDeX.Domain.Repositories.Operation
{
    public interface ISelect<T> where T : EntityBase
    {
        T Select(int entityId);
        IQueryable<T> All();
    }
}
