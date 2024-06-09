using DentoApp.Data.Abstract;
using DentoApp.Data.Concrete;
using DentoApp.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();





builder.Services.AddDbContext<DentoContext>(options => {options.UseSqlite(builder.Configuration["ConnectionStrings:sql_connection"]);});

// builder.Services.AddScoped<IDentistRepository, EfDentistRepository>();
// builder.Services.AddScoped<IPatientRepository, EfPatientRepository>();
// builder.Services.AddScoped<IAppointmentRepository, EfAppointmentRepository>();
// builder.Services.AddScoped<ITreatmentRepository, EfTreatmentRepository>();

var app = builder.Build();

SeedData.AddTestData(app);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
