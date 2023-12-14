using AutoMapper;
using LibraryManagementSystem.Application.Contracts.Persistence;
using LibraryManagementSystem.Application.MappingProfiles;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Application.Features.Book.Queries.GetAllBooks;
using Shouldly;

namespace LibraryManagementSystem.AppLayer.UnitTests.Features.BookFeature.Query
{
    public  class GetAllBooksQueryHandlerTests
    {
       
        [Fact]
        public async Task Handle_ShouldReturnAllBooks()
        {
            // Arrange 
            var mockBookRepo = new Mock<IBookRepository>();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<BookProfile>();
            });

           var  mapper = mapperConfig.CreateMapper();

            var bookLst = new List<Domain.Entities.Book>
            {
                new Domain.Entities.Book
                {
                    Id = 1,
                    Author = "Jonathan",
                    IsActive = true,
                    ISBN = 12223333333,
                    Title = "Title_1",

                },
                new Domain.Entities.Book
                {
                    Id = 2,
                    Author = "Mutala",
                    IsActive = true,
                    ISBN = 12223333333,
                    Title = "Title_2",
                },
                new Domain.Entities.Book
                {
                    Id = 3,
                    Author = "Bobstrong",
                    IsActive = false,
                    ISBN = 12223333333,
                    Title = "Title_3",
                }

            };

            mockBookRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(bookLst);
            var handler = new GetAllBooksQueryHandler(mapper, mockBookRepo.Object);

            // Act 

            var result = await handler.Handle(new GetAllBooksQuery(), CancellationToken.None);


            //Assert
            result.Count.ShouldBe(3); 
        }

        [Fact]
        public async Task Handle_ShouldReturnAllActiveBooks()
        {
            // Arrange 
            var mockBookRepo = new Mock<IBookRepository>();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<BookProfile>();
            });

            var mapper = mapperConfig.CreateMapper();

            var bookLst = new List<Domain.Entities.Book>
            {
                new Domain.Entities.Book
                {
                    Id = 1,
                    Author = "Jonathan",
                    IsActive = true,
                    ISBN = 12223333333,
                    Title = "Title_1",

                },
                new Domain.Entities.Book
                {
                    Id = 2,
                    Author = "Mutala",
                    IsActive = true,
                    ISBN = 12223333333,
                    Title = "Title_2",
                },
                new Domain.Entities.Book
                {
                    Id = 3,
                    Author = "Bobstrong",
                    IsActive = false,
                    ISBN = 12223333333,
                    Title = "Title_3",
                }

            };

            mockBookRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(() =>
            {
                return bookLst.Where(book => book.IsActive).ToList();
            });
            var handler = new GetAllBooksQueryHandler(mapper, mockBookRepo.Object);

            // Act 

            var result = await handler.Handle(new GetAllBooksQuery(), CancellationToken.None);


            //Assert
            result.Count.ShouldBe(2);
        }



    }
}
