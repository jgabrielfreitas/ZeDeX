using Microsoft.EntityFrameworkCore;

namespace ZeDeX.Infrastructure.EntityFramework.DbMap
{
    public abstract class DbMapBase
    {
        public abstract void ModelBuilder(ModelBuilder model);
    }
}
