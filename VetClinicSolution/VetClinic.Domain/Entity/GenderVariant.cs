using VetClinic.Domain.Enum;

namespace VetClinic.Domain.Entity
{
    public class GenderVariant
    {
        public GenderVariantId GenderVariantId { get; set; }
        public string Name { get; set; }

        public ICollection<VetPassportEntity> VetPassports;
    }
}
