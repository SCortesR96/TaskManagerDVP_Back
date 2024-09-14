using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.User.Models.DTO
{
    public class UpdateUserDTO
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        public string SecondLastName { get; set; } = null!;
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        public int RolId { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public bool IsActived { get; set; }
    }
}
