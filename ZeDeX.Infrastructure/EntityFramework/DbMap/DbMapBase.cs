using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeDeX.Infrastructure.EntityFramework.DbMap
{
    public abstract class DbMapBase
    {
        public abstract void ModelBuilder(ModelBuilder model);
    }
}
