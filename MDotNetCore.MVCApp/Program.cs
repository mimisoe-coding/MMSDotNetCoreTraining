using MDotNetCore.MVCApp;
using MDotNetCore.MVCApp.Controllers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Refit;
using RestSharp;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MSDBConnection"));
});

builder.Services.AddScoped<IDbConnection, SqlConnection>(n => new SqlConnection(builder.Configuration.GetConnectionString("MSDBConnection")));
var restApiUrl = builder.Configuration.GetSection("RestApiUrl").Value;
builder.Services.AddScoped(n => new HttpClient { BaseAddress = new Uri(restApiUrl) });
builder.Services.AddScoped(n => new RestClient(restApiUrl));
builder.Services.AddRefitClient<IPaintingApi>().ConfigureHttpClient(c => c.BaseAddress = new Uri(restApiUrl));
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
