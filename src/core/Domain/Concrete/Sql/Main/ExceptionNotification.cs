using Domain.Concrete.Base;
using Domain.Concrete.Sql.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete.Main
{
    public class ExceptionNotification : BaseSqlEntityWithCreate
    {
        public int LangId { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }

        //Relations
        public Language Lang { get; set; }
    }
}
