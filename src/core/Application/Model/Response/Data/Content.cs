using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.Response.Data
{
    public class Content
    {
        public Content(string key,string description)
        {
            Key = key;
            Description = description;
        }
        public string Key { get; set; }
        public string Description { get; set; }
    }
}
