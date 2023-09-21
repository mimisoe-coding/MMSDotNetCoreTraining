using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDotNetCore.MVCApp.Models
{
    [Table("Book")]
    public class BookModel
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string? Name { get; set; }

        public string? Author { get; set; }

        public string? Category { get; set; }

        public int Price { get; set; }
    }
}
