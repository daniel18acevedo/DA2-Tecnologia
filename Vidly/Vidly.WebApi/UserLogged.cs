using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly.WebApi
{
    public class UserLogged
    {
        public string Id { get; set; }
        
        public string Name { get; set; }

        public string[] Permissions { get; set; }
    }
}