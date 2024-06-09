using Microsoft.EntityFrameworkCore;

namespace DentoApp.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void AddTestData(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<DentoContext>();
            if(context != null)
            {
                if(context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if(!context.Dentists.Any())
                {
                    context.Dentists.AddRange(
                        new Entity.Dentist { Name = "Taskin Ozcan" },
                        new Entity.Dentist { Name = "Eli Hafif" }
                    );
                    context.SaveChanges();
                }

                if(!context.Patients.Any())
                {
                    context.Patients.AddRange(
                        new Entity.Patient { Name = "Mervan" },
                        new Entity.Patient { Name = "Nurefsan" }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}