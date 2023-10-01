// See https://aka.ms/new-console-template for more information
//using System.Data.SqlClient;
//Console.WriteLine("Hello, World!");
//SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder
//{
//    DataSource = ".\\DESKTOP-PEU8G7Q",
//    InitialCatalog = "",
//    UserID = "sa",
//    Password = "sa@123"
//};

//SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
//sqlConnection.Open();
//sqlConnection.Close();
//Console.ReadLine();

//using MDotNetCore.ConsoleApp.AdoDotNetExamples;

//AdoDotExample adoDotExample = new AdoDotExample();
//adoDotExample.Run();

//using MDotNetCore.ConsoleApp.HttpClientExamples;
//using MMSHomework.DapperExamples;

//DapperExample dapperExample = new DapperExample();
//dapperExample.Run();

//using MDotNetCore.ConsoleApp.EFCoreExamples;
//try
//{
//    EFCoreExample eFCoreExample = new EFCoreExample();
//    await eFCoreExample.Run();
//}
//catch (Exception e)
//{
//    Console.WriteLine(e.ToString());
//}

using MDotNetCore.ConsoleApp.HttpClientExamples;
using MDotNetCore.ConsoleApp.RefitExamples;

//try
//{
//Statement:
//    Console.ReadKey();
//    HttpClientExample httpClient = new HttpClientExample();
//    await httpClient.Run();
//    goto Statement;
//}
//catch (Exception e)
//{
//    Console.WriteLine(e.Message);
//}

using MDotNetCore.ConsoleApp.RestClientExamples;
using Serilog;
using Serilog.Sinks.MSSqlServer;

//try
//{
//Statement:
//    Console.ReadKey();
//    //RestClientExample example = new RestClientExample();
//    //await example.Run();
//    RefitExample refitExample = new RefitExample();
//    await refitExample.Run();
//    goto Statement;
//}
//catch (Exception e)
//{
//    Console.WriteLine(e.ToString());
//}
Console.WriteLine("Hello, World!");

string filePath = Path.Combine("D:\\ace\\serilog", "myapp.txt");
Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                //.WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Hour)
                //.WriteTo.File(filePath, rollingInterval: RollingInterval.Day)
                //.CreateLogger();
                .WriteTo.File(filePath, rollingInterval: RollingInterval.Hour)
                .WriteTo
                .MSSqlServer(
                    connectionString: "Server=.;Database=TestDb;User ID=sa;Password=sa@123;TrustServerCertificate=true;",
                    sinkOptions: new MSSqlServerSinkOptions { TableName = "Tbl_LogEvent", AutoCreateSqlTable = true })
                .CreateLogger();

Log.Information("Hello, world!");

int a = 10, b = 0;
try
{
    Log.Debug("Dividing {A} by {B}", a, b);
    Console.WriteLine(a / b);
}
catch (Exception ex)
{
    Log.Error(ex, "Something went wrong");
}
finally
{
    Log.CloseAndFlush();
}

