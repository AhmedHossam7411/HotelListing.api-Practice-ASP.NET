﻿using System.ComponentModel.DataAnnotations;

namespace HotelListing.api.Dto
{
    public class ApiUserDto : LoginDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
                                                 
    }
}
