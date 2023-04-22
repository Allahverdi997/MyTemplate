using Application.Abstraction.Core.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.App
{
    public class AppSession:IAppSession
    {
        public string SecretKey { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int LangId { get; set; }
        public object UserPermissions { get; set; }
    }
}
