using SuperPets.Data;
using SuperPets.Domain.Animals;

namespace SuperPets.Endpoints.Animals
{
    public class AnimalPost
    {
        public static string Template => "/animals";
        public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action(AnimalRequest animalRequest, AppDbContext context)
        {
            var animal = new Animal
            {
                Name = animalRequest.Name,
                Description = animalRequest.Description,
                Species = animalRequest.Species,
                Gender = animalRequest.Gender,
                Age = animalRequest.Age,
                Size = animalRequest.Size,
                Local = animalRequest.Local,
                Vaccines = animalRequest.Vaccines,
                Castration = animalRequest.Castration,
                Photo = animalRequest.Photo,
                CreatedBy = animalRequest.CreatedBy,
                CreatedOn = DateTime.Now,
                UpdatedBy = animalRequest.UpdatedBy,
                UpdatedOn = DateTime.Now,                
            };

            context.Animals.Add(animal);
            context.SaveChanges();

            return Results.Created($"/animals/{animal.Id}", animal.Id);
        }
    }
}
