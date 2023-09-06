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

using MMSHomework.DapperExamples;

DapperExample dapperExample = new DapperExample();
dapperExample.Run();

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



