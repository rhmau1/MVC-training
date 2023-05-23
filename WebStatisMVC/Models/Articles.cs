using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebStatisMVC.Models
{
    public class Articles
    {
        [Key]
        public int id { get; set; }
        public string? Title { get; set; }
        [AllowHtml]
        public string? Description { get; set; }
        [StringLength(160, MinimumLength = 3)]
        public string? Excerpt { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Publish_date { get; set; }
        public string? Author { get; set; }
        public int? Time_read { get; set; }

        public string? Category { get; set; }
        public string? Featured_images { get; set; }
    }
}
