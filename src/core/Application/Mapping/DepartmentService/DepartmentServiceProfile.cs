using Application.DTO;
using AutoMapper;
using Domain.Concrete.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping.DepartmentService
{
    public class DepartmentServiceProfile:Profile
    {
        public DepartmentServiceProfile()
        {
            CreateMap<DepartmentGetAllDTO, Department>().ReverseMap();
        }
    }
}
