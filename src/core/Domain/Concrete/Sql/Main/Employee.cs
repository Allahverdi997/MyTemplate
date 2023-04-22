using Domain.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete.Main
{
    public class Employee : BaseSqlEntityWithCreate
    {
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }

        //Relations
        public Department Department { get; set; }
    }
}
