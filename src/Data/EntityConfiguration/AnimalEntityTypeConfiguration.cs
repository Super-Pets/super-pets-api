using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperPets.Models.Animal;

namespace SuperPets.Data.EntityConfiguration
{
    public class AnimalEntityTypeConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder
                .Property(p => p.Description)
                .HasColumnType("varchar(200)");

            builder
                .Property(p => p.Species)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder
                .Property(p => p.Gender)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder
                .Property(p => p.Age)
                .IsRequired();

            builder
                .Property(p => p.Size)
                .IsRequired();

            builder
                .ToTable("Animals");
        }
    }
}
