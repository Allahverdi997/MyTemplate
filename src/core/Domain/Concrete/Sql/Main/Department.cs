using Domain.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete.Main
{
    public class Department:BaseSqlEntityWithCreate
    {
        public string Name { get; set; }
        public string Description { get; set; }

        //Relations
        public List<Employee> Employees { get; set; }
    }
}
