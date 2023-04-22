using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashingService.Abstract
{
    public interface IHashService
    {
        string EncryptePassword(string password,string key);
        string DecryptePassword(string hashedPassword, string key);
    }
}
