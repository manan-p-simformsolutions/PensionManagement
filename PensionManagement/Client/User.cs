using Microsoft.AspNetCore.Identity;

namespace PensionManagement.Shared.Models
{
    public class User : IdentityUser
    {
        public int Userid { get; set; }
        public string Username { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Mobilenumber { get; set; } = null!;
      //  public string Email { get; set; } = null!;
        public DateTime Date { get; set; }
    }
}
