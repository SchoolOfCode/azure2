using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LibraryApi.Models;
using LibraryApi.Data;
using System.Collections.Generic;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;

        public BooksController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAll()
        {
            var books = await _booksRepository.GetAll();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetById(int id)
        {
            var books = await _booksRepository.GetById(id);
            return Ok(books);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> AddBook(Book entity)
        {
            await _booksRepository.Add(entity);
            return Ok(entity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> Update(Book entity, int id)
        {
            await _booksRepository.Update(entity, id);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _booksRepository.Remove(id);
            return Ok();
        }
    }
}
