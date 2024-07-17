using DentoApp.Data.Concrete.EfCore.Data;
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
                    var dentist1 = context.Dentists.FirstOrDefault();
                    var patient1 = context.Patients.FirstOrDefault();

                    if (dentist1 != null && patient1 != null)
                    {
                        context.Treatments.AddRange(
                            new Entity.Treatment 
                            { 
                                DentistId = dentist1.Id, 
                                PatientId = patient1.Id, 
                                TreatmentType="Dolgu", 
                                TreatmentDate = DateTime.Now, 
                                TreatmentDuration = 30, 
                                TreatmentDescription = "Dolgu tedavisi", 
                                Price = 150
                            },
                            new Entity.Treatment 
                            { 
                                DentistId = dentist1.Id, 
                                PatientId = patient1.Id, 
                                TreatmentType="Kanal Tedavisi", 
                                TreatmentDate = DateTime.Now.AddDays(1), 
                                TreatmentDuration = 60, 
                                TreatmentDescription = "Kanal tedavisi", 
                                Price = 300
                            }
                        );
                        context.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Required related data (Dentist, Patient) not found in the database.");
                    }
                }


                if (!context.Appointments.Any())
                {
                    var patient1 = context.Patients.FirstOrDefault();
                    var dentist1 = context.Dentists.FirstOrDefault();
                    var treatment1 = context.Treatments.FirstOrDefault();

                    if (patient1 != null && dentist1 != null && treatment1 != null)
                    {
                        context.Appointments.AddRange(
                            new Entity.Appointment 
                            { 
                                PatientId = patient1.Id, 
                                DentistId = dentist1.Id, 
                                TreatmentId = treatment1.Id, 
                                AppointmentDate = DateTime.Now, 
                                TreatmentType = treatment1.TreatmentType, 
                                Notes = "First appointment" 
                            },
                            new Entity.Appointment 
                            { 
                                PatientId = patient1.Id, 
                                DentistId = dentist1.Id, 
                                TreatmentId = treatment1.Id, 
                                AppointmentDate = DateTime.Now.AddDays(1), 
                                TreatmentType = treatment1.TreatmentType, 
                                Notes = "Second appointment" 
                            }
                        );
                        context.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Required related data (Dentist, Patient, Treatment) not found in the database.");
                    }
                }
            
            }
        }
    }
}