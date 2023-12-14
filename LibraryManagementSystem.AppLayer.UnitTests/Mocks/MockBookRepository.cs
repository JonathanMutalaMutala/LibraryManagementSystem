using LibraryManagementSystem.Application.Contracts.Persistence;
using LibraryManagementSystem.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.AppLayer.UnitTests.Mocks
{
    public  class MockBookRepository
    {
        public static Mock<IBookRepository> GetMockBookRepository()
        {
            // Arrange 

            var mockBookRepository = new Mock<IBookRepository>();


            var bookLst = new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Author = "Jonathan",
                    IsActive = true,
                    ISBN = 12223333333,
                    Title = "Title_1",

                },
                new Book
                {
                    Id = 2,
                    Author = "Mutala",
                    IsActive = true,
                    ISBN = 12223333333,
                    Title = "Title_2",
                },
                new Book
                {
                    Id = 3,
                    Author = "Bobstrong",
                    IsActive = false,
                    ISBN = 12223333333,
                    Title = "Title_3",
                }

            };

            mockBookRepository.Setup(x => x.GetAllAsync());

            return mockBookRepository;

        }
    }
}
