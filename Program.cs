using DentoApp.Data.Abstract;
using DentoApp.Data.Concrete;
using DentoApp.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DentoContext>(options => {
    var config = builder.Configuration;
    var connectionString = config.GetConnectionString("sql_connection");
    options.UseSqlite(connectionString);});

// builder.Services.AddScoped<IDentistRepository, EfDentistRepository>();
// builder.Services.AddScoped<IPatientRepository, EfPatientRepository>();
// builder.Services.AddScoped<IAppointmentRepository, EfAppointmentRepository>();
// builder.Services.AddScoped<ITreatmentRepository, EfTreatmentRepository>();

var app = builder.Build();

SeedData.AddTestData(app);

app.MapGet("/",() => "Hello World");
app.Run();

// Configure the HTTP request pipeline.
