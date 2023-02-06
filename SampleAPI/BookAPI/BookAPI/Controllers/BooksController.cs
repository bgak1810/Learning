using BookAPI.Data;
using BookAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Reflection;

namespace BookAPI.Controllers
{
    [ApiController] /* data annotations*/
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly BooksAPIDBContext _dbContext;
        /* this will talk to the inmemory database*/

        public BooksController(BooksAPIDBContext dbContext)
        {
            this._dbContext = dbContext;
        }
        [HttpGet]  /* annotate */
        public async Task<IActionResult> GetBooks()
        {
            return Ok(await _dbContext.PropBooks.ToListAsync());

        }
        [HttpPost]  /* annotate if not annotated will result failed to load swagger in the browser*/
        public async Task<IActionResult> AddBook(NewBook newBook)
        {
            var book = new Books()
            {
                bookid = Guid.NewGuid(),
                bookname = newBook.bookname,
                author = newBook.author,
                price = newBook.price
            };
            await _dbContext.PropBooks.AddAsync(book);
            await _dbContext.SaveChangesAsync();
            return Ok(book);

        }

        [HttpGet]
        [Route("{bookid:guid}")]
        public async Task<IActionResult> GetBook([FromRoute] Guid bookid)
        {
            var book = await _dbContext.PropBooks.FindAsync(bookid);
            if (book != null)
            {
                return Ok(book);
            }
            return NotFound();
        }



        [HttpPut]
        [Route("{bookid:guid}")]
        public async Task<IActionResult> UpdateBook([FromRoute] Guid bookid, NewBook _book)
        {
            var book = await _dbContext.PropBooks.FindAsync(bookid);
            if (book != null)
            {
                book.bookname = _book.bookname;
                book.author = _book.author;
                book.price = _book.price;
                await _dbContext.SaveChangesAsync();
                return Ok(book);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{bookid:guid}")]
        public async Task<IActionResult> DeleteBook([FromRoute] Guid bookid)
        {
            var book = await _dbContext.PropBooks.FindAsync(bookid);
            if (book != null)
            {
                _dbContext.Remove(book);
                await _dbContext.SaveChangesAsync();
                return Ok();
            }
            return NotFound("Record Not Found");
        }
    }
}
