using LibraryManagementSystem.Application.Contracts.Persistence;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Persistence.Repositories
{
    public class BookRepository : GenericRepository<Domain.Entities.Book>,IBookRepository
    {
        public BookRepository(LibraryManagementSystemDbContext context) : base(context)
        {

        }
    }
}
