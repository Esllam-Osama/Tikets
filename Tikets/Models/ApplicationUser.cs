

using Microsoft.AspNetCore.Identity;

namespace Tikets.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string? Address { get; set; }
    }
}
