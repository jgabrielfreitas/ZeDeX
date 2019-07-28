using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ZeDeX.Domain.Common
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
