using VetClinic.Domain.Enum;

namespace VetClinic.Domain.Entity
{
    public class VetPassportEntity
    {
        public Guid Id { get; set; }
        public string? FullNameOwner { get; set; }
        public string? Nickname { get; set; }
        public string? Telephone { get; set; }
        public string? AnumalView { get; set;}
        public string? Breed { get; set; }
        public Gender Gender { get; set; }
    }
}
