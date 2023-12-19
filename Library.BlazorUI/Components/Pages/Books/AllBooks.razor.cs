using Library.BlazorUI.Contracts.Book;
using Library.BlazorUI.Models.BookModel;
using Microsoft.AspNetCore.Components;

namespace Library.BlazorUI.Components.Pages.Books
{
    public partial class AllBooks
    {
        [Inject] IBookService bookService { get; set; }

        public List<BookVM> BookVMs { get; set; } = new List<BookVM>();


        protected override async Task OnInitializedAsync()
        {
           BookVMs = await bookService.GetAllBooks();
        }

    }
}