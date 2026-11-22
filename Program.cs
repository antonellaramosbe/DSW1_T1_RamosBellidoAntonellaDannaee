
using DSW1_T1_RamosBellidoAntonellaDannaee.Repositories;
using DSW1_T1_RamosBellidoAntonellaDannaee.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Registrar servicios y repositorios
builder.Services.AddScoped<ILibroServices, LibroServices>();
builder.Services.AddScoped<ILibroRepository, LibroRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Libro}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
