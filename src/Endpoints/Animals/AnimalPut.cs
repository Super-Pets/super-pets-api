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

        public static IResult Action([FromRoute] int id, AnimalRequest animalRequest, AppDbContext context)
        {
            var animal = context.Animals.Where(a => a.Id == id).FirstOrDefault();

            if (animal != null)
            {
                animal.Name = animalRequest.Name;
                animal.Description = animalRequest.Description;
                animal.Vaccines = animalRequest.Vaccines;
                animal.Species = animalRequest.Species;
                animal.Age = animalRequest.Age;
                animal.Gender = animalRequest.Gender;
                animal.Castration = animalRequest.Castration;
                animal.Local = animalRequest.Local;
                animal.Photo = animalRequest.Photo;
                animal.Size = animalRequest.Size;

                context.SaveChanges();
                return Results.Ok();
            }

            throw new Exception("Animal não encontrado.");
        }
    }
}
