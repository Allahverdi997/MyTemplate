using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Core.App
{
    public interface IAppSession
    {
        public string SecretKey { get; set; }
        public int LangId { get; set; }
        public object UserPermissions { get; set; }
    }
}
