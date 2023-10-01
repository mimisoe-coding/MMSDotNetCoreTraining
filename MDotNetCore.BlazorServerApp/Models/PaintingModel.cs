using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDotNetCore.BlazorServerApp.Models
{
    [Table("Tbl_Painting")]
    public class PaintingModel
    {
        [Key]
        [Column("PaintingId")]
        public int PaintingId { get; set; }

        [Column("PaintingName")]
        public string? PaintingName { get; set; }

        [Column("PaintingType")]
        public string? PaintingType { get; set; }

        [Column("PaintingPrice")]
        public decimal PaintingPrice { get; set; }
    }
}
