using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Models
{
    public class User : BaseModel
    {
       
        public string UserName { get; set; }

        public string Password { get; set; }

        public byte RoleId { get; set; }

        public Role Role { get; set; }
    }
}
