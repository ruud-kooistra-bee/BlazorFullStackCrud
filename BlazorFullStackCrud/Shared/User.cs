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

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [StringLength(16, ErrorMessage = "Your username is too long (16 characters max)")]
        public string Username { get; set; } = string.Empty;

        [Required, StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;

        [Compare("Password", ErrorMessage = "The passwords do not match")]
        public string ConfirmPassword { get; set; } = string.Empty;

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public Role? Role { get; set; }

        public int RoleId { get; set; }

        public DateTime DateOfBirth { get; set; } = DateTime.Now;
    }
}
