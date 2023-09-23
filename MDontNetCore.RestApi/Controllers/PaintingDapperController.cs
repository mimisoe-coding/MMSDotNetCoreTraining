
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Dapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Reflection.Metadata;
using MDotNetCore.RestApi.Models;

namespace MDotNetCore.RestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaintingDapperController : ControllerBase
{
    private readonly IDbConnection _connection;

    public PaintingDapperController(IDbConnection connection)
    {
        _connection = connection;
    }

    [HttpGet]
    public async Task<IActionResult> GetPaintingAsync()
    {
        string query = "select * from Tbl_Painting";
        var result = await _connection.QueryAsync<PaintingModel>(query);
        List<PaintingModel> models = result.ToList();
        return Ok(models);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> EditPaintingAsync(int id)
    {
        string query = @"
SELECT *
  FROM Tbl_Painting WHERE @PaintingId=PaintingId";
        var item = await _connection.QueryFirstOrDefaultAsync<PaintingModel>(query, new { PaintingId = id });
        if (item is null)
        {
            return NotFound(new { Message = $"No Data Found with id {id}" });
        }
        return Ok(new { Data = item });

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePaintingAsync(int id)
    {
        string query = @"
DELETE 
  FROM Tbl_Painting WHERE @PaintingId=PaintingId";
        var result = await _connection.ExecuteAsync(query, new
        {
            PaintingId = id
        });
        if (result > 0)
        {
            return Ok(new { Message = "Deletion success" });
        }
        return NotFound(new { Message = $"No Data Found with id {id}" });
    }

    [HttpPost]
    public async Task<IActionResult> CreatePainting(PaintingModel model)
    {
        string query = @"
INSERT INTO [dbo].[Tbl_Painting]
           ([PaintingName]
           ,[PaintingType]
           ,[PaintingPrice])
     VALUES
           (@PaintingName
           ,@PaintingType
           ,@PaintingPrice)";

        var result = await _connection.ExecuteAsync(query, model);
        if (result > 0)
        {
            return Ok(new { Message = "Insertion Success" });
        }
        else
        {
            return BadRequest(new { Message = "Insertion Failed" });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutPaintingAsync(int id, PaintingModel model)
    {
        model.PaintingId = id;
        string query = @"
SELECT *
  FROM Tbl_Painting WHERE @PaintingId=PaintingId";
        var item = await _connection.QueryFirstOrDefaultAsync<PaintingModel>(query, new { PaintingId = id });
        if (item is null)
        {
            return NotFound(new { Message = $"No Data Found with id {id}" });
        }

        string putQuery = @"UPDATE [dbo].[Tbl_Painting]
                            SET [PaintingName] = @PaintingName, [PaintingType] = @PaintingType, [PaintingPrice] = @PaintingPrice
                            WHERE PaintingId = @PaintingId";
        var result = await _connection.ExecuteAsync(putQuery, model);
        if (result > 0)
        {
            return Ok(new { Message = "Updating Success", Data = model });
        }
        else
        {
            return BadRequest(new { Message = "Updating Failed" });
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchPaintingAsync(int id, PaintingModel model)
    {
        model.PaintingId = id;
        string query = @"
SELECT *
  FROM Tbl_Painting WHERE @PaintingId=PaintingId";
        var item = await _connection.QueryFirstOrDefaultAsync<PaintingModel>(query, new { PaintingId = id });
        if (item is null)
        {
            return NotFound(new { Message = $"No Data Found with id {id}" });
        }
        string conditions = "";
        if (!string.IsNullOrWhiteSpace(model.PaintingName))
        {
            conditions += " [PaintingName] = @PaintingName, ";
            item.PaintingName = model.PaintingName;
        }
        if (!string.IsNullOrWhiteSpace(model.PaintingType))
        {
            conditions += " [PaintingType] = @PaintingType, ";
            item.PaintingType = model.PaintingType;
        }

        conditions += " [PaintingPrice] = @PaintingPrice, ";
        item.PaintingPrice = item.PaintingPrice;

        //if(conditions.Length == 0)
        if (string.IsNullOrWhiteSpace(conditions))
        {
            string message = "No data to update.";
            return BadRequest(new { Message = message });
        }

        conditions = conditions.Substring(0, conditions.Length - 2);

        string queryUpdate = $@"UPDATE [dbo].[Tbl_Painting] SET {conditions} WHERE PaintingId = @PaintingId";

        var result = await _connection.ExecuteAsync(queryUpdate, model);

        if (result > 0)
        {
            string message = "Updating Successful!";
            item = await _connection.QueryFirstOrDefaultAsync<PaintingModel>(query, new { PaintingId = id });
            return Ok(new { Message = message, Data = item });
        }
        else
        {
            string message = "Updating Failed.";
            return BadRequest(new { Message = message });
        }
    }
}
