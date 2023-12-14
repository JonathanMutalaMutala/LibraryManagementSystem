using LibraryManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Persistence.Configuration
{
    /// <summary>
    /// Cette classe permettra de seed les books 
    /// </summary>
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        List<Book> lstBooks = new List<Book>
        {
            new Book
            {
                Id = 1,
                Author = "Chinua Achebe", 
                Title = "Things Fall Apart",
                ISBN = 1222303444, 
                IsActive = true,
            },
            new Book
            {
                Id = 2,
                Author = "Christian Andersen",
                Title = "Fairy tales",
                ISBN = 599998774412,
                IsActive = true,


            },
            new Book
            {
                Id = 3,
                Author = "Unknown",
                Title = "The Epic Of Gilgamesh",
                ISBN = 599998774412,
                IsActive = true,
            },

        };
        public void Configure(EntityTypeBuilder<Book> builder)
        {

            builder.HasData(lstBooks);
        }
    }
}
