using System.ComponentModel.DataAnnotations.Schema;

namespace ZeDeX.Infrastructure.EntityFramework.PersistenceModel
{
    public abstract class EntityPersistenceModelBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
