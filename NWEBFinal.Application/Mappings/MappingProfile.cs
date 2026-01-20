using AutoMapper;
using NWEBFinal.Application.DTOs;
using NWEBFinal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWEBFinal.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
        }
    }
}
