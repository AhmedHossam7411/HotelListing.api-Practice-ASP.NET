using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.api.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        // seeding new identity User roles , can do other configurations here as well
        public void Configure(EntityTypeBuilder<IdentityRole> builder) 
        {
            builder.HasData(
               new IdentityRole
               {
                   Id= "123", // Unique identifier for the role
                   Name = "User",
                   NormalizedName = "USER"
               },
               new IdentityRole
               {
                   Id = "12",
                   Name = "Administrator",
                   NormalizedName = "ADMINISTRATOR"
               }
               );
        }
    }
}
