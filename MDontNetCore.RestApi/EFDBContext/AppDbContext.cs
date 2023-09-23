﻿using Microsoft.EntityFrameworkCore;
using MDotNetCore.RestApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MDotNetCore.RestApi.EFDBContext
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

        public DbSet<PaintingModel> Painting { get; set; }
    }
}
