using Microsoft.EntityFrameworkCore;
using SuperPets.Data.EntityConfiguration;

namespace SuperPets.Models.Animal
{
    [EntityTypeConfiguration(typeof(AnimalEntityTypeConfiguration))]
    public class Animal
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string Species { get; set; }
        public required string Gender { get; set; }
        public int Age { get; set; }
        public required List<AnimalSize> Size { get; set; }
        public string? Local { get; set; }
        public string? Vaccines { get; set; }
        public bool Castration { get; set; }
        public string? Photo { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public required string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
