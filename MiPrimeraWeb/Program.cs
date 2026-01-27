using MiPrimeraWebBLL;
using MiPrimeraWebBLL.Servicios.Carro;
using MiPrimeraWebDAL.Repositorios.Carro;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



//  Inyeccion de dependencias de las interfaces que implementamos
builder.Services.AddSingleton<ICarroRepositorio, CarroRepositorio>  ();
builder.Services.AddSingleton<ICarroServicio, CarroServicio> (); //CONFIGURACION INICIAL DE LAS INTERFACES Y CLASES SERVICIOS Y REPOSITORIOS




// Inyeccion de librerias
builder.Services.AddAutoMapper(cfg => { }, typeof(MapeoClases)); //Yo no lo se




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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
