using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly.WebApi.Domain
{
    public class User
    {
        public bool HasPermissions(string[] permissions)
        {
            return true;
        }
    }
}