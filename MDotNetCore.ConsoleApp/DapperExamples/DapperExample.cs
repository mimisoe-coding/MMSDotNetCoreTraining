using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMSHomework.Models;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace MMSHomework.DapperExamples
{
    public class DapperExample
    {
        private readonly SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder
        {
            DataSource = ".",
            InitialCatalog = "testDB",
            UserID = "sa",
            Password = "sa@123"
        };

        public void Run()
        {
            Read();
            //Update(3, "ThuThu");
            //Create("Kyaw", "Sagaing");
            Delete(1);
            Edit(3);
        }

        private void Read()
        {
            using IDbConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            string query = "select * from student";
            List<StudentModel> lst = connection.Query<StudentModel>(query).ToList();

            foreach (StudentModel model in lst)
            {
                Console.WriteLine($"Id => {model.Id}");
                Console.WriteLine($"Name => {model.Name}");
                Console.WriteLine($"City => {model.City}");
            }
        }

        private void Update(int id, string name)
        {
            string query = @"
UPDATE [dbo].[student]
   SET [name] = @Name   
 WHERE @Id=id";
            using IDbConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            var result = connection.Execute(query, new StudentModel { Id = id, Name = name });

            string message = result > 0 ? "Updating Successful.!" : "Updating Failed.";
            Console.WriteLine(message);
        }

        private void Create(string name, string city)
        {
            string query = @"
INSERT INTO [dbo].[student]
           ([name]
           ,[city])
     VALUES
           (@Name,
            @City)";

            using IDbConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            var result = connection.Execute(query, new StudentModel { Name = name, City = city });
            string message = result > 0 ? "Creating Successful.!" : "Creating Failed.";
            Console.WriteLine(message);
        }

        private void Delete(int id)
        {
            string query = @"
DELETE FROM [dbo].[student]
      WHERE @Id=id";
            using IDbConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            var result = connection.Execute(query, new StudentModel
            {
                Id = id
            });
            string message = result > 0 ? "Deleting Successful.!" : "Deleting Failed.";
            Console.WriteLine(message);
        }

        private void Edit(int id)
        {
            string query = @"
SELECT [id]
      ,[name]
      ,[city]
  FROM [dbo].[student] WHERE @Id=id";
            using IDbConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            var item = connection.Query<StudentModel>(query, new StudentModel { Id = id }).FirstOrDefault();

            Console.WriteLine($"Id => {item.Id}");
            Console.WriteLine($"Name => {item.Name}");
            Console.WriteLine($"City => {item.City}");
        }
    }

}
