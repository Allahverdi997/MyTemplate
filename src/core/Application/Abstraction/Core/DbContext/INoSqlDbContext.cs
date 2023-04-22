using Domain.Abstract.Marker;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Core.DbContext
{
    public interface INoSqlDbContext
    {
        IMongoCollection<T> GetCollection<T>() where T : class, INoSqlEntity;
    }
}
