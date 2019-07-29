using System.Threading.Tasks;

namespace ZeDeX.Domain.Common
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
