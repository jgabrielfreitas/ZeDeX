using ZeDeX.Domain.Common.Entities;

namespace ZeDeX.Domain.Repositories.Operation
{
    public interface IInsert<T> where T : EntityBase
    {
        void Insert(T entity);
    }
}
