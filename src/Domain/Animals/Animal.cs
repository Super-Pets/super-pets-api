using Microsoft.EntityFrameworkCore;
using SuperPets.Data.EntityConfiguration;
using System.ComponentModel.DataAnnotations;

namespace SuperPets.Domain.Animals
{
    [EntityTypeConfiguration(typeof(AnimalEntityTypeConfiguration))]
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Species { get; set; }
        public string? Gender { get; set; }
        public int Age { get; set; }
        public string? Size { get; set; }
        public string? Local { get; set; }
        public string? Vaccines { get; set; }
        public bool Castration { get; set; }
        public string? Photo { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
