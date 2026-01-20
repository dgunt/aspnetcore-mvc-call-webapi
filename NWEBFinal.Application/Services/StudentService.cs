using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NWEBFinal.Application.DTOs;
using NWEBFinal.Domain.Entities;
using NWEBFinal.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWEBFinal.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly NWebFinalDbContext  _ctx;
        private readonly IMapper _mapper;

        public StudentService(NWebFinalDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<List<StudentDto>> GetAllAsync()
            => _mapper.Map<List<StudentDto>>(await _ctx.Students.ToListAsync());

        public async Task<StudentDto?> GetByIdAsync(int id)
            => _mapper.Map<StudentDto?>(await _ctx.Students.FindAsync(id));

        public async Task<StudentDto> CreateAsync(StudentDto dto)
        {
            var ent = _mapper.Map<Student>(dto);
            _ctx.Students.Add(ent);
            await _ctx.SaveChangesAsync();
            return _mapper.Map<StudentDto>(ent);
        }

        public async Task<bool> UpdateAsync(int id, StudentDto dto)
        {
            var ent = await _ctx.Students.FindAsync(id);
            if (ent == null) return false;
            _mapper.Map(dto, ent);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var ent = await _ctx.Students.FindAsync(id);
            if (ent == null) return false;
            _ctx.Students.Remove(ent);
            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}
