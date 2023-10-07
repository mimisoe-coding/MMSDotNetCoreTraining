using System;
using System.Collections.Generic;

namespace MDotNetCore.DbService.AppDbContextModels;

public partial class TblPainting
{
    public int PaintingId { get; set; }

    public string? PaintingName { get; set; }

    public string? PaintingType { get; set; }

    public decimal? PaintingPrice { get; set; }
}
