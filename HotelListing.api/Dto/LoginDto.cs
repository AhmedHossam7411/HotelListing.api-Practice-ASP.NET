using System.ComponentModel.DataAnnotations;

namespace HotelListing.api.Dto
{
    public class LoginDto 
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "password is limited ", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
