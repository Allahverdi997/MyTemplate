using Application.Abstraction.Core.App;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.App
{
    public class AppSetting : IAppSetting
    {
        private readonly IConfiguration _config;

        public AppSetting(IConfiguration config)
        {
            _config = config;
        }
        public string SqlConnectionString => Setting<string>("ConnectionStrings.DefaultSql");

        public string MongoDatabase => Setting<string>("Mongo.Database.Name");

        private T Setting<T>(string name)
        {
            var configValue = name.Split(".");
            IConfigurationSection configurationSection = null;
            configurationSection = _config.GetSection(configValue[0]);
            for (int i = 1; i < configValue.Length; i++)
            {
                configurationSection = GetCustomSection(configurationSection, configValue[i]);
            }
            string value = configurationSection.Value;

            if (value == null)
            {
                throw new KeyNotFoundException(string.Format("Could not find setting '{0}',", name));
            }

            return (T)Convert.ChangeType(value, typeof(T));
        }

        private IConfigurationSection GetCustomSection(IConfigurationSection section,string value)
        {
            return section.GetSection(value);
        }
    }
}
