using System;
using System.Collections.Generic;

namespace MDotNetCore.DbService.AppDbContextModels;

public partial class Book
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Author { get; set; }

    public string? Category { get; set; }

    public int Price { get; set; }
}
