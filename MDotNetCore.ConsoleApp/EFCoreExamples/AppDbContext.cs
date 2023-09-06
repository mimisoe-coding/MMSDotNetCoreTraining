using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MDotNetCore.ConsoleApp.EFCoreExamples
{
    public class AppDbContext:DbContext
    {
        SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder
        {
            DataSource = ".",
            InitialCatalog = "testDB",
            UserID = "sa",
            Password = "sa@123",
            TrustServerCertificate = true,
        };

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);
            }
        }

        public DbSet<Models.PaintingModel> paintingModel { get; set; }
    }
}
