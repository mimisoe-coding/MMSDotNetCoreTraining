using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDotNetCore.ConsoleApp.AdoDotNetExamples
{
    public class AdoDotExample
    {
        SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder
        {
            DataSource = ".",
            InitialCatalog = "testDB",
            UserID = "sa",
            Password = "sa@123"
        };
        public void Run()
        {
           // Read();
            // Delete(1);
            //Create(4,"NY", "33");
            //Update(3, "SS");
            //Edit(4);
        }

        private void Create(int id, string name, string age)
        {
            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            String query = @"
INSERT INTO [dbo].[people]
           ([id]
           ,[name]
           ,[age])
     VALUES
           (@Id
           ,@Name
           ,@Age)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Age", age);
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            string message = result > 0 ? "Insertion success" : "Unsuccess";
            Console.WriteLine(message);

        }

        private void Read()
        {
            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = "select * from people";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine($"Name =>{dr["name"].ToString()}");
                Console.WriteLine($"Age =>{dr["age"].ToString()}");
            }
        }

        private void Delete(int id)
        {
            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            String query = "delete from people where id=@Id";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Id", id);
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            string message = result > 0 ? "Deletion success" : "Unsuccess";
            Console.WriteLine(message);

        }

        private void Update(int id, string name)
        {

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            String query = @"
UPDATE [dbo].[people]
   SET 
      [name] = @Name
 WHERE id=@Id";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", name);
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            string message = result > 0 ? "Updating success" : "Unsuccess";
            Console.WriteLine(message);

        }

        private void Edit(int id)
        {
            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            connection.Open();

            string query = "select * from people where id=@Id";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            if (dt.Rows.Count == 0)
            {
                return;
            }
            DataRow dr = dt.Rows[0];
            Console.WriteLine($"Name =>{dr["name"].ToString()}");
            Console.WriteLine($"Age =>{dr["age"].ToString()}");
        }
    }
}
