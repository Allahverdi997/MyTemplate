﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete.Sql.Base
{
    public abstract class BaseSqlEntity
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? EditDate { get; set; }

        public int? EditorId { get; set; }
        public bool? IsActive { get; set; }

    }
}
