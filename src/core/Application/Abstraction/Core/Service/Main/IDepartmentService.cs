using Application.DTO;
using Domain.Concrete.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Core.Service.Main
{
    public interface IDepartmentService
    {
        public IEnumerable<DepartmentGetAllDTO> GetAll();
        public bool Check();
        public int Count();
        public Department FirstOrDefault(object obj);
        public IQueryable<Department> Get();
        public IQueryable<Department> GetId();
        public IEnumerable<Department> GetAllEst();
        public void Add(Department department);
        public void AddRange(IEnumerable<Department> departments);
        public void AddOrUpdate(Department department, int id);
        public void DeleteId(int id);
        public void Delete(Department department);
        public void DeleteRange();
    }
}
