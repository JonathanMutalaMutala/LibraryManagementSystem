using AutoMapper;
using LibraryManagementSystem.Application.Contracts.Persistence;
using LibraryManagementSystem.Application.Exceptions;
using LibraryManagementSystem.Application.Features.Book.Commands.CreateBook;
using LibraryManagementSystem.Application.MappingProfiles;
using LibraryManagementSystem.Domain.Entities;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.AppLayer.UnitTests.Features.BookFeature.Command
{
    public class CreateBookCommandHandlerTests
    {

        [Fact]
        public async Task Should_Add_Book()
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

            // Setup 
            mockBookRepo.Setup(x => x.CreateAsync(It.IsAny<Book>()))
               .Returns((Book book) =>
               {
                   bookLst.Add(book);
                   return Task.CompletedTask;
               });


            var handler = new CreateBookCommandHandler(mapper, mockBookRepo.Object);

            var command = new CreateBookCommand
            {
                Title = "Title_33",
                Author = "Jonjon",
                IsActive = true,
                ISBN = 1223344
            };

            // Action 
            var result = await handler.Handle(command, CancellationToken.None); 

            //Arrange 
            bookLst.Count.ShouldBe(4);

        }
        [Fact]
        public async Task Should_ReturnBadRequestDataInvalid()
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

            // Setup 
            mockBookRepo.Setup(x => x.CreateAsync(It.IsAny<Book>()))
               .Returns((Book book) =>
               {
                   bookLst.Add(book);
                   return Task.CompletedTask;
               });


            var handler = new CreateBookCommandHandler(mapper, mockBookRepo.Object);

            var command = new CreateBookCommand
            {
                Title = "",
                Author = "Jonjon02owowsissiisisisiisis",
                IsActive = true,
                ISBN = 1223344
            };

            //Arrange 
             await Assert.ThrowsAnyAsync<BadRequestException>(async () => await handler.Handle(command, CancellationToken.None));

        }



    }
}
