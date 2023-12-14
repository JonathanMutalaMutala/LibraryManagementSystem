using AutoMapper;
using LibraryManagementSystem.Application.Features.Book.Queries.Dtos;
using LibraryManagementSystem.Application.Features.Book.Queries.GetAllBooks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IMediator _mediator;  

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }




        // GET: api/<BookController>
        [HttpGet]
        public async Task<List<BookDto>> GetAllBooks()
        {
            var bookLst = _mediator.Send(new GetAllBooksQuery());

            return bookLst.Result; 
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BookController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
