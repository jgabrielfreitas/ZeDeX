using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZeDeX.Domain.Common.Entities;

namespace ZeDeX.Domain.Repositories.Operation
{
    public interface ISelect<T> where T : EntityBase
    {
        T Select(int entityId);
        IQueryable<T> All();
    }
}
