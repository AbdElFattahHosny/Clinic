using Clinic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.ViewModels
{
    public class UserViewModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public byte RoleId { get; set; }

        public IEnumerable<Role> Roles { get; set; }
    }
}
