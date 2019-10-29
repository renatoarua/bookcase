using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Service.Interface;

namespace BookcaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        //GET: api/Book
        [HttpGet("{username}")]
        public async Task<IEnumerable<TabBook>> Get(string username)
        {
            return await _bookService.booksTake(username);
        }

        // GET: api/Book/5
        [HttpGet("{bookId}")]
        public async Task<TabBook> Get(int bookId)
        {
            return await _bookService.bookTake(bookId);
        }

        // POST: api/Book
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TabBook book)
        {
            var saved = await _bookService.bookSave(book);
            return Ok(saved);
        }

        // PUT: api/Book/5
        [HttpPut("{userId}")]
        public async Task<IActionResult> Put([FromBody]TabBook book, int userId)
        {
            var saved = await _bookService.bookUpdate(book, userId);

            if (!saved) return BadRequest("Something is wrong. Try again.");

            return Ok(saved);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{bookId}/{userId}")]
        public async Task<IActionResult> Delete(int bookId, int userId)
        {
            var deleted = await _bookService.bookDelete(bookId, userId);
            
            if (!deleted) return BadRequest("Something is wrong. Try again.");

            return Ok(deleted);
        }
    }
}
