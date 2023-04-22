using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Core.App
{
    public interface IAppSetting
    {
        string SqlConnectionString { get; }
        string MongoDatabase { get; }
    }
}
