using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SuperPets.Data;
using SuperPets.Domain.Animals;
using System.Drawing;
using System.Reflection;

namespace SuperPets.Endpoints.Animals
{
    public class AnimalPut
    {
        public static string Template => "/animals/{id}";
        public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action([FromRoute] int id, AnimalRequest animalRequest, AppDbContext context)
        {
            var animal = context.Animals.Find(id);

            if (animal is null) return Results.NotFound();

            if(!animalRequest.Name.IsNullOrEmpty())
                animal.Name = animalRequest.Name;

            if (!animalRequest.Description.IsNullOrEmpty())
                animal.Description = animalRequest.Description;

            if (!animalRequest.Species.IsNullOrEmpty())
                animal.Species = animalRequest.Species;

            if (!animalRequest.Gender.IsNullOrEmpty())
                animal.Gender = animalRequest.Gender;

            if (animalRequest.Age != 0)
                animal.Age = animalRequest.Age;

            if (!animalRequest.Size.IsNullOrEmpty())
                animal.Size = animalRequest.Size;

            if (!animalRequest.Local.IsNullOrEmpty())
                animal.Local = animalRequest.Local;

            if (!animalRequest.Vaccines.IsNullOrEmpty())
                animal.Vaccines = animalRequest.Vaccines;

            animal.Castration = animalRequest.Castration;
            animal.UpdatedBy = animalRequest.UpdatedBy;
            animal.UpdatedOn = DateTime.Now;


            context.Animals.Update(animalRequest);
            context.SaveChanges();

            return Results.Ok();
        }
}
}
