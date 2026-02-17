using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;
using MiPrimeraWebBLL;
using MiPrimeraWebBLL.Servicios.Carro;
using MiPrimeraWebDAL.Data;
using MiPrimeraWebDAL.Repositorios.Carro;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configuracion de la conexion a la base de datos SQL LITE
builder.Services.AddDbContext<MiPrimeraWebDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


//  Inyeccion de dependencias de las interfaces que implementamos
builder.Services.AddScoped<ICarroRepositorio, CarroRepositorio>  ();
builder.Services.AddScoped<ICarroServicio, CarroServicio> (); //CONFIGURACION INICIAL DE LAS INTERFACES Y CLASES SERVICIOS Y REPOSITORIOS


// Inyeccion de librerias
builder.Services.AddAutoMapper(cfg => { }, typeof(MapeoClases)); //Yo no lo se






//builder.Services.AddDbContext<ProyectoPersonaContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));











// Configuracion de secretos y variables de entorno





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();


app.UseMiddleware<MiPrimeraWeb.Middleware.MiddlewareGlobalExceptionHandler>(); //Agregamos el middleware de manejo global de excepciones a la tuberia de procesamiento de solicitudes

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
