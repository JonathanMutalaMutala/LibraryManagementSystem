using System.ComponentModel.DataAnnotations;

namespace Library.BlazorUI.Models.BookModel
{
    public class BookVM
    {
        public int Id { get; set; }

        public string Title { get; set; } 

        public string Author { get; set; }

        public long ISBN { get; set; }

        public bool IsActive { get; set; }
    }
}
