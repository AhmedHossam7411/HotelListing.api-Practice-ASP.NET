using Microsoft.AspNetCore.Identity;

namespace HotelListing.api.data
{
    public class ApiUser : IdentityUser  // whatever required for user to build secure system
    {
        public ApiUser() : base()
        {
            
        }
        public override string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName  { get; set; }
    }

}
