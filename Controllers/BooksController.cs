using LibraryManager.Data;
using LibraryManager.Models;
using LibraryManager.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace LibraryManager.Controllers
{
    public class BooksController : LibraryManagerBaseController
    {
        private readonly Repository.Interface.IBookRepository bookRepository;
        public BooksController(Repository.Interface.IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBooks()
        {
            try
            {
                return Ok(await bookRepository.GetBooks());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(Book),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            try
            {
                var result = await bookRepository.GetBookById(id);

                if (result == null)
                {
                    return NotFound($"Book with Id = {id} not found");
                }

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Book), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest("The book information was not provided.");
            }

            var existingBook = await bookRepository.GetBookById(book.BookId);

            if (existingBook != null)
            {
                return BadRequest("Cannot create a book with the provided id because it already exists");
            }

            try
            {
                var createdBook = await bookRepository.AddBook(book);

                return CreatedAtAction(nameof(GetBooks), new { id = createdBook.BookId }, createdBook);
            } catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new book record");
            }
        }
    }
}

