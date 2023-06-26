using booklibrary.Entities;
using Microsoft.AspNetCore.Identity;

namespace library.Authorization
{
    
}
public class LibraryUser : IdentityUser
{
    public bool RatingsAllowed { get; set; }
    public ICollection<BookReview> Reviews {get; set;}
}