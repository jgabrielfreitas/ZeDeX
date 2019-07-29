using ZeDeX.Infrastructure.EntityFramework.PersistenceModel.Partner;

namespace ZeDeX.Infrastructure.EntityFramework.PersistenceModel.Employer
{
    public class EmployerPersistenceModel : EntityPersistenceModelBase
    {
        public bool IsOwner { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public PartnerPersistenceModel Partner { get; set; }
    }
}
