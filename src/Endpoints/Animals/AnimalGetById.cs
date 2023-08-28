using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using SuperPets.Data;
using SuperPets.Domain.Animals;

namespace SuperPets.Endpoints.Animals
{
    public class AnimalGetById
    {
        public static string Template => "/animals/{id}";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action([FromRoute] int id, AppDbContext context)
        {
            var animal = context.Animals.Find(id);

            if(animal != null)
                return Results.Ok(animal);

            return Results.NotFound();
        }
    }
}
