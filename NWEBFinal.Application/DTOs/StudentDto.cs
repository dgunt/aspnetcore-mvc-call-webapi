using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWEBFinal.Application.DTOs
{
    public class StudentDto
    {
        public int StudentId { get; set; }

        [Required, StringLength(150)]
        public string FullName { get; set; } = null!;

        [Required]
        public DateOnly DateOfBirth { get; set; }

        [Required, StringLength(100), EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; } = null!;

        [StringLength(20)]
        public string? PhoneNumber { get; set; }

        [StringLength(250)]
        public string? Address { get; set; }
    }
}
