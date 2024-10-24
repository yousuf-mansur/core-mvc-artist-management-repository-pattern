using CoreWebApp.Models;
using CoreWebApp.Repository;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ArtistDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("con")));


builder.Services.AddScoped<IArtistRepository, ArtistSQlRepository>();


var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(name: "Default", pattern: "{Controller=Artist}/{action=Index}/{id?}");

app.Run();
