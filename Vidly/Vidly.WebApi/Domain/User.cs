using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly.WebApi.Domain
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string[] Permissions { get; set; }

        public bool HasPermissions(string[] permissions)
        {
            var hasPermission =  this.Permissions.ToList().Any(permission => permissions.Contains(permission));

            return hasPermission;
        }
    }
}