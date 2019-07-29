using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZeDeX.Domain.Common.Entities;

namespace ZeDeX.Infrastructure.EntityFramework.Repositories
{
    public abstract class RepositoryBase
    {
        protected readonly ZedexContext _context;

        public RepositoryBase(ZedexContext context)
        {
            _context = context;
        }
    }
}
