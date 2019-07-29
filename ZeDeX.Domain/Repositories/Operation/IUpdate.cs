using System;
using System.Collections.Generic;
using System.Text;
using ZeDeX.Domain.Common.Entities;

namespace ZeDeX.Domain.Repositories.Operation
{
    public interface IUpdate<T>  where T : EntityBase
    {
        void Update(T entity);
    }
}
