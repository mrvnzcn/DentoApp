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
                        new Entity.Dentist {Name = "Taskin Ozcan", 
                                            Age=55, 
                                            Email="taskinozcan@gmail.com", 
                                            Gender="male", 
                                            PhoneNumber="5332232121", 
                                            Profession="endodonti", 
                                            WorkingHours = new List<string> { "Weekdays 9am-5pm"}
                                            
                                            },
                        new Entity.Dentist {Name = "Eli Hafif", 
                                            Age=55, 
                                            Email="elihafif@gmail.com", 
                                            Gender="male", 
                                            PhoneNumber="5555555555", 
                                            Profession="ortodonti", 
                                            WorkingHours = new List<string> { "Weekend 9am-2pm"}
                                            }
                    );
                    context.SaveChanges();
                }

                if(!context.Patients.Any())
                {
                    context.Patients.AddRange(
                        new Entity.Patient {Name = "Mervan", 
                                            Address="istanbul", 
                                            Age=27, 
                                            BirthDate = new DateOnly(1997,8,7),
                                            Email="imervanozcan@gmail.com", 
                                            Gender="male", 
                                            PhoneNumber="5349318717", 
                                            Attachments=new List<string> {"sonTahlil.jpg"},
                                            
                                            },
                        new Entity.Patient {Name = "Nurefsan", 
                                            Address="atina", 
                                            Age=21, 
                                            BirthDate = new DateOnly(2002,9,25),
                                            Email="nurefsan-05@gmail.com", 
                                            Gender="female", 
                                            PhoneNumber="5388381212", 
                                            Attachments=new List<string> { "rontgenDis.pdf"},
                                            }
                    );
                    context.SaveChanges();
                }

                if(!context.Treatments.Any())
                {
                    context.Treatments.AddRange(
                        new Entity.Treatment {TreatmentType="Dolgu"},
                        new Entity.Treatment {TreatmentType="Kanal Tedavisi"}
                    );
                    context.SaveChanges();
                }
            
            }
        }
    }
}