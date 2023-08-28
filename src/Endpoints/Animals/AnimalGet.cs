using Microsoft.AspNetCore.DataProtection.Repositories;
using SuperPets.Data;
using SuperPets.Domain.Animals;

namespace SuperPets.Endpoints.Animals
{
    public class AnimalGet
    {
        public static string Template => "/animals";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action(AppDbContext context)
        {
            var Animals = context.Animals.ToList();
            var Response = Animals.Select(a => new AnimalResponse
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,
                Species = a.Species,
                Gender = a.Gender,
                Age = a.Age,
                Size = a.Size,
                Local = a.Local,
                Vaccines = a.Vaccines,
                Castration = a.Castration,
                Photo = a.Photo
            });

            return Results.Ok(Response);
        }
    }
}
