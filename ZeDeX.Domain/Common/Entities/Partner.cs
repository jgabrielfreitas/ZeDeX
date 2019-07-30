namespace ZeDeX.Domain.Common.Entities
{
    public class Partner : EntityBase
    {
        public string DocumentNumber { get; set; }
        public string Name { get; set; }
        public OwnerEmployee Owner { get; set; }
        public Address Address { get; set; }
        public CoverageArea CoverageArea { get; set; }
    }
}
