using Microsoft.AspNetCore.Mvc;
using SuperPets.Data;
using SuperPets.Domain.Animals;

namespace SuperPets.Endpoints.Animals
{
    public class AnimalDelete
    {
        public static string Template => "/animals/{id}";
        public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action([FromRoute] int id, AnimalRequest animalRequest, AppDbContext context)
        {
            var animal = context.Animals.Find(id);

            if (animal != null)
            {
                context.Remove(animal);
                context.SaveChanges();
                return Results.Ok();
            }

            throw new Exception("Animal não encontrado.");
        }
    }
}
