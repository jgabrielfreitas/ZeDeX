using ZeDeX.Domain.Common.Entities;

namespace ZeDeX.Domain.Repositories.Operation
{
    public interface IUpdate<T> where T : EntityBase
    {
        void Update(T entity);
    }
}
