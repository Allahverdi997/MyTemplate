using Domain.Concrete.Base;
using Domain.Concrete.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete.Sql.Main
{
    public class Language : BaseSqlEntityWithCreate
    {
        public string Name { get; set; }
        public string Shortname { get; set; }

        //Relations
        public ICollection<ExceptionNotification> ExceptionNotifications { get; set; }
    }
}
