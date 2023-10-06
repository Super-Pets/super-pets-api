using Microsoft.AspNetCore.Mvc;
using SuperPets.Data;
using SuperPets.Domain.Animals;

namespace SuperPets.Endpoints.Animals
{
    public class AnimalPut
    {
        public static string Template => "/animals/{id}";
        public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action([FromRoute] int id, [FromBody] AnimalRequest animalRequest, AppDbContext context)
        {
            var animal = context.Animals.Find(id);

            if(animal != null)
            {
                context.Animals.Update(animalRequest);
                var result = context.SaveChanges();
            }
            return Results.Ok();
        }
    }
}
