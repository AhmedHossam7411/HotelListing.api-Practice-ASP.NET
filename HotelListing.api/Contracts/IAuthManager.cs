using HotelListing.api.data;
using HotelListing.api.Dto;
using Microsoft.AspNetCore.Identity;

namespace HotelListing.api.Contracts
{
    public interface IAuthManager 
    {
        Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto);
        Task<AuthResponseDto> Login(LoginDto loginDto);
        Task<string> CreateToken();
    }
}
