using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Core.Service.Other
{
    public interface IMemoryCacheService
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object data, int duration);
        bool IsAdd(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern);
    }
}
