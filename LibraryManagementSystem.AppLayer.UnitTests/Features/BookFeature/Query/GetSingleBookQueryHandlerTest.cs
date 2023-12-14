using AutoMapper;
using LibraryManagementSystem.Application.Contracts.Persistence;
using LibraryManagementSystem.Application.Exceptions;
using LibraryManagementSystem.Application.Features.Book.Queries.Dtos;
using LibraryManagementSystem.Application.Features.Book.Queries.GetAllBooks;
using LibraryManagementSystem.Application.Features.Book.Queries.GetSIngleBook;
using LibraryManagementSystem.Application.MappingProfiles;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.AppLayer.UnitTests.Features.BookFeature.Query
{
    public class GetSingleBookQueryHandlerTest
    {
        [Fact]
        public async Task Should_ReturnSingleBook()
        {
            // Arrange 
            var mockIBookRepository = new Mock<IBookRepository>();
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

            mockIBookRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
              .ReturnsAsync((int id) =>
              {
                  return bookLst.Single(b => b.Id == id);
              });

            var handler = new GetSingleBookQueryHandler(mockIBookRepository.Object, mapper);


            // Action 

            var result = await handler.Handle(new GetSingleBookQuery { Id = 2}, CancellationToken.None); 

            // Assert

            result.ShouldBeOfType<BookDto>();

        }

        [Fact]
        public async Task Should_ReturnCorrespondingActiveBook()
        {
            // Arrange 
            var mockIBookRepository = new Mock<IBookRepository>();
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

            mockIBookRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
             .ReturnsAsync((int id) =>
             {
                 return bookLst.Single(b => b.Id == id && b.IsActive);
             });

            var handler = new GetSingleBookQueryHandler(mockIBookRepository.Object, mapper);

            // Action 

            var result = await handler.Handle(new GetSingleBookQuery { Id = 2 }, CancellationToken.None);

            // Assert

            result.ShouldBeOfType<BookDto>();

        }

        [Fact]
        public async Task GetSingleBookQuery_WhenBookIsInvalid_ThrowsNotFoundException()
        {
            // Arrange 
            var mockIBookRepository = new Mock<IBookRepository>();
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

            mockIBookRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
             .ReturnsAsync((int id) =>
             {
                 return bookLst.SingleOrDefault(b => b.Id == id && b.IsActive) ?? null;
             });

            var handler = new GetSingleBookQueryHandler(mockIBookRepository.Object, mapper);

          
            // Assert
            await Assert.ThrowsAnyAsync<NotFoundException>(async () => await handler.Handle(new GetSingleBookQuery { Id = 900 }, CancellationToken.None));

        }

    }
}
