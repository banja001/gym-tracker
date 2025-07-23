using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members.API.Dtos
{
    public class RegisteredUserDto
    {
        public long Id { get; set; }
        public string Username { get; set; }

        public RegisteredUserDto(long id, string username)
        {
            Id = id;
            Username = username;
        }
    }
}
