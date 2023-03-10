using System.ComponentModel.DataAnnotations;

namespace VetClinic.Domain.Entity
{
    public class PetOwnerEntity
    {
        [Key]
        public long PetOwnerId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string? Building { get; set; }
        public string Flat { get; set; }

        public string Phone { get; set; }
    }
}
