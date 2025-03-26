using Microsoft.EntityFrameworkCore;
using PracticaMVC.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromSeconds(3600);
    option.Cookie.HttpOnly = true;
    option.Cookie.IsEssential = true;
});

//Inyeccion por dependencia del string de conexion

builder.Services.AddDbContext<equiposDbContext>(opt =>
    opt.UseSqlServer(
        builder.Configuration.GetConnectionString("equiposDbConnection")
    )
);


var app = builder.Build();

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

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
