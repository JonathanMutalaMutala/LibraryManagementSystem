namespace LibraryManagementSystem.Application.Features.Book.Queries.GetSIngleBook
{
    public class BookDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public long ISBN { get; set; }
    }
}
