using System;
using System.Collections.Generic;

namespace MDotNetCore.DbService.AppDbContextModels;

public partial class Atmaccount
{
    public int AccountId { get; set; }

    public string? AccountNumber { get; set; }

    public string? AccountFirstName { get; set; }

    public string? AccountLastName { get; set; }

    public int? AccountPassword { get; set; }

    public decimal? AccountBalance { get; set; }
}
