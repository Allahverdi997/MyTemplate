using Domain.Abstract.Marker;
using Domain.Concrete.Sql.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete.Base
{
    public abstract class BaseSqlEntityWithCreate:BaseSqlEntity, ISqlEntity
    {
        public int CreatorId { get; set; }

    }
}
