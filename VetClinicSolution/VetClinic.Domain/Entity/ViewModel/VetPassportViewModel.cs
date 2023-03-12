using VetClinic.Domain.Enum;

namespace VetClinic.Domain.Entity.ViewModel
{
    public class VetPassportViewModel
    {
        public string PetName { get; set; }
        public string Breed { get; set; }
        public string SpecialSigns { get; set; }
        public DateOnly Birthday { get; set; }

        public long MicrochipNumber { get; set; }
        public DateOnly MicrochipDate { get; set; }
        public string LocationOfMicrochip { get; set; }

        public GenderVariantId GenderVariantId { get; set; }

        public long PetOwnerId { get; set; }
    }
}
