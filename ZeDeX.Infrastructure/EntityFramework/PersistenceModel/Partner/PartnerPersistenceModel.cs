using ZeDeX.Infrastructure.EntityFramework.PersistenceModel.Address;
using ZeDeX.Infrastructure.EntityFramework.PersistenceModel.CoverageArea;
using ZeDeX.Infrastructure.EntityFramework.PersistenceModel.Employer;

namespace ZeDeX.Infrastructure.EntityFramework.PersistenceModel.Partner
{
    public class PartnerPersistenceModel : EntityPersistenceModelBase
    {
        public string DocumentNumber { get; set; }
        public string Name { get; set; }
        public int CoverageAreaId { get; set; }
        public int AddressId { get; set; }
        public int OwnerId { get; set; }
        public AddressPersistenceModel Address { get; set; }
        public CoverageAreaPersistenceModel CoverageArea { get; set; }
        public EmployerPersistenceModel Owner { get; set; }
    }
}
