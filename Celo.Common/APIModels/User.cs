using Celo.Common.APIModels;
using System;

namespace Celo.Common
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public Name Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PhoneNumber { get; set; }

        public Picture ProfileImage { get; set; } 
    }
}
