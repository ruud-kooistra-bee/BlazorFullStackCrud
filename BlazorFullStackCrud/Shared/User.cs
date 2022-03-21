using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFullStackCrud.Shared
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
 
        public int RoleId { get; set; } 

        public DateTime DateOfBirth { get; set; } = DateTime.Now;
    } 
}
