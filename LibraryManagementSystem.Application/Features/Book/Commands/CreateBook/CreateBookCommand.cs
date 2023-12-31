﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Features.Book.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<int>
    {
        public string Title { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public long ISBN { get; set; }

        public bool IsActive { get; set; }
    }
}
