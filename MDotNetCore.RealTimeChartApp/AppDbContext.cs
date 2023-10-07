﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MDotNetCore.RealTimeChartApp
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //private readonly SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder
        //{
        //    DataSource = ".",
        //    InitialCatalog = "MMYDotNetCore",
        //    UserID = "sa",
        //    Password = "sa@123",
        //    TrustServerCertificate = true,
        //};

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);
        //    }
        //}
        public DbSet<PieChartModel> pieChart { get; set; }  
       // public DbSet<PaintingModel> Painting { get; set; }
    }
    [Table("Tbl_PieChart")]
    public class PieChartModel
    {
        [Key]
        public int PieChartId { get; set; } 
        public string PieChartLabel { get; set; }
        public int PieChartSeries { get; set;}
    }
}