using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebAppBookList.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string  Name { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        [DisplayName("Date Of Publication")]
        public DateTime DateOfPublication { get; set; } = DateTime.Now;

    }
}
