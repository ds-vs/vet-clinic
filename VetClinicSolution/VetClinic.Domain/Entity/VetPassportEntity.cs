using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VetClinic.Domain.Enum;

namespace VetClinic.Domain.Entity
{
    public class VetPassportEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long VetPassportId { get; set; }

        public string PetName { get; set; }
        public string Breed { get; set; }
        public string SpecialSigns { get; set; }
        public DateOnly Birthday { get; set; }

        public long MicrochipNumber { get; set; }
        public DateOnly MicrochipDate { get; set; }
        public string LocationOfMicrochip { get; set; }

        public GenderVariantId GenderVariantId { get; set; }
        public GenderVariant GenderVariant { get; set; }

        public long PetOwnerId { get; set; }
        public PetOwnerEntity? PetOwner { get; set; }
    }
}
