using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Extension.Redis
{
    public static class RedisCacheExtension
    {
        public static JsonSerializerOptions Options => new JsonSerializerOptions()
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            WriteIndented = true
        };
        public static void SetRecordAsync(this IDistributedCache cache, string key, Type type, object data, TimeSpan? absoluteExpire = null, TimeSpan? unuseExpire = null)
        {
            var options = new DistributedCacheEntryOptions();

            options.AbsoluteExpirationRelativeToNow = absoluteExpire ?? TimeSpan.FromMinutes(60);
            options.SlidingExpiration = unuseExpire;

            var jsonData = JsonSerializer.Serialize(data,type,Options);
            cache.SetStringAsync(key,jsonData,options).Wait();
        }

        public static  object GetRecord(this IDistributedCache cache,string key,Type type)
        {
            var jsonData=cache.GetString(key);

            if (jsonData == null)
                return null;

            return JsonSerializer.Deserialize(jsonData, type,Options);
        }
    }
}
