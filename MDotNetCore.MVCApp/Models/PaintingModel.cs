using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDotNetCore.MVCApp.Models
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
    public class PageSettingModel
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public string PageUrl { get; set; }
    }
}
