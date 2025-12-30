using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Models
{
    public class Book
    {
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Genre { get; set; }
        [Range(0,100000d)]
        public double Price { get; set; }
        [Range(0, 999)]
        public int Stock { get; set; }
    }
}
