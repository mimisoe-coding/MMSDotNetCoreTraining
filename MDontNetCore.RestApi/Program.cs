using MDotNetCore.RestApi.EFDBContext;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

var builderConfig = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
var configuration = builderConfig.Build();

Console.WriteLine("************************************************Painting Info ********************************************");
string filePath = Path.Combine("D:\\ace\\serilog", "paintingInfo.txt");
Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                //.WriteTo.Console()
                //.WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Hour)
                .WriteTo.File(filePath, rollingInterval: RollingInterval.Day)
                .WriteTo.MSSqlServer(
                 connectionString: configuration.GetConnectionString("MSDbConnection"),
                 sinkOptions: new MSSqlServerSinkOptions { TableName = "Tbl_LogEvent", AutoCreateSqlTable = true })
                 .CreateLogger();


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://127.0.0.1:5500")
                                                    .AllowAnyHeader()
                                                    .AllowAnyMethod();
                      });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MSDBConnection"));
});
builder.Host.UseSerilog();
builder.Services.AddScoped<IDbConnection, SqlConnection>(n => new SqlConnection(builder.Configuration.GetConnectionString("MSDBConnection")));
var app = builder.Build();


    // Configure the HTTP request pipeline.;
    if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();

