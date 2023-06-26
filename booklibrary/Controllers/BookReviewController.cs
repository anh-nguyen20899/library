using booklibrary.Data;
using booklibrary.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace booklibrary.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ReviewController : ControllerBase
{
    public List<BookReview> booksystem = new List<BookReview>()
    {
        new BookReview() {Id = 1, Title = "Name 1", Rating = 1.5},
        new BookReview() {Id = 2, Title = "Name 2", Rating = 1.5},
        new BookReview() {Id = 3, Title = "Name 3", Rating = 1.5},

    };
    [HttpGet]
    public IActionResult GetBookReviews()
    {
        return Ok(booksystem);
    }
}