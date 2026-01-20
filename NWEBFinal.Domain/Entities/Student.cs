using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWEBFinal.Domain.Entities
{
    public class Student
    {
        public int StudentId {  get; set; }
        public string FullName { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; }
        public string Email { get; set; } = null!;
        public string? PhoneNumber {  get; set; }
        public string? Address {  get; set; }
    }
}
