using booklibrary.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace booklibrary.Data;
public class BookReviewContext : IdentityDbContext
{
    public List<BookReview> booksystem = new List<BookReview>()
    {
        new BookReview() {Id = 1, Title = "Name 1", Rating = 1.5},
        new BookReview() {Id = 2, Title = "Name 2", Rating = 1.5},
        new BookReview() {Id = 3, Title = "Name 3", Rating = 1.5},

    };

    public BookReviewContext(DbContextOptions<BookReviewContext> options) : base(options)
    {
 
    }
    public DbSet<BookReview> BookReviews {get; set;}
    public DbSet<LibraryUser> LibraryUsers {get; set;}
}