using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Features.Book.Commands.Dtos
{
    public class CreateBookDto
    {
        public string Title { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public long ISBN { get; set; }
    }
}
