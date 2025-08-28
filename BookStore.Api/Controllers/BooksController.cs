using BookStore.Api.DTO;
using BookStore.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _svc;
        public BooksController(IBookService svc) => _svc = svc;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _svc.GetAllAsync();
            return Ok(new
            {
                success = true,
                message = books.Any() ? "Books retrieved successfully." : "No books found.",
                data = books
            });
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var book = await _svc.GetByIdAsync(id);
            if (book == null)
                return NotFound(new { success = false, message = $"Book with ID {id} not found." });

            return Ok(new { success = true, message = "Book retrieved successfully.", data = book });
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string? title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return BadRequest(new { success = false, message = "Query 'title' is required." });

            var results = await _svc.SearchAsync(title);

            return Ok(new
            {
                success = true,
                message = results.Any() ? "Search results found." : "No books matched the search criteria.",
                data = results
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { success = false, message = "Invalid input.", errors = ModelState });

            var created = await _svc.CreateAsync(dto);

            return CreatedAtAction(nameof(Get), new { id = created.Id }, new
            {
                success = true,
                message = "Book successfully created.",
                data = created
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, BookUpdateDto dto)
        {
            var updated = await _svc.UpdateAsync(id, dto);

            if (updated == null)
                return NotFound(new { success = false, message = $"Book with ID {id} not found." });

            return Ok(new
            {
                success = true,
                message = "Book successfully updated.",
                data = updated
            });
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _svc.DeleteAsync(id);

            if (!deleted)
                return NotFound(new { success = false, message = $"Book with ID {id} not found." });

            return Ok(new { success = true, message = "Book successfully deleted." });
        }
    }
}
