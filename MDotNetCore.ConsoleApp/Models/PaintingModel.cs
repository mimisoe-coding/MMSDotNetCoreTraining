using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDotNetCore.ConsoleApp.Models
{
    [Table("Painting")]
    public class PaintingModel
    {
        [Key]
        [Column("Id")]
        public int PaintingId { get; set; }

        [Column("Name")]
        public string PaintingName { get; set; }

        [Column("Type")]
        public string PaintingType { get; set; }

        [Column("Price")]
        public decimal PaintingPrice { get; set; }

    }
}
