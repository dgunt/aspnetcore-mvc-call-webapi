using NWEBFinal.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWEBFinal.Application.Services
{
    public interface IStudentService
    {
        Task<List<StudentDto>> GetAllAsync();
        Task<StudentDto?> GetByIdAsync(int id);
        Task<StudentDto> CreateAsync(StudentDto dto);
        Task<bool> UpdateAsync(int id, StudentDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
