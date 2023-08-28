using Microsoft.EntityFrameworkCore;
using SuperPets.Data;

namespace SuperPets.Services
{
    public static class DatabaseManagementService
    {
        public static void MigrationInitialization(this IApplicationBuilder app)
        {
            using (var superpetsScope = app.ApplicationServices.CreateScope())
            {
                var SuperPetsDb = superpetsScope.ServiceProvider
                                    .GetService<AppDbContext>();

                SuperPetsDb.Database.Migrate();
            }
        }
    }
}
