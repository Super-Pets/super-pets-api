using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperPets.Domain.Animals;

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
                .HasColumnType("varchar(20)");

            builder
                .Property(p => p.Gender)
                .HasColumnType("varchar(10)");

            builder
                .Property(p => p.Vaccines)
                .HasColumnType("varchar(max)");

            builder
                .Property(p => p.Castration)
                .HasColumnType("bit");


            builder
                .ToTable("Animals");
        }
    }
}
