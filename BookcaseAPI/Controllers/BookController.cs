using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Service.Interface;

namespace BookcaseAPI.Controllers
{
    [Route("v1/[controller]")]
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
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Get(string username)
        {
            return Ok(await _bookService.booksTake(username));
        }

        // GET: api/Book/GetById/5 , [FromHeader]string Authorization
        [HttpGet("GetById/{bookId}")]
        public async Task<IActionResult> GetById(int bookId)
        {
            var book = await _bookService.bookTake(bookId);

            if (book == null) return BadRequest("Book not found.");

            return Ok(book);
        }

        // POST: api/Book
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Post([FromBody]TabBook book)
        {
            var saved = await _bookService.bookSave(book);
            return Ok(saved);
        }

        // PUT: api/Book/5
        [HttpPut("{userId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Put([FromBody]TabBook book, int userId)
        {
            var saved = await _bookService.bookUpdate(book, userId);

            if (!saved) return BadRequest("Something is wrong. Try again.");

            return Ok(saved);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{bookId}/{userId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Delete(int bookId, int userId)
        {
            var deleted = await _bookService.bookDelete(bookId, userId);
            
            if (!deleted) return BadRequest("Something is wrong. Try again.");

            return Ok(deleted);
        }
    }
}
