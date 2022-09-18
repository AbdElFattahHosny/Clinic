using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Models
{
    public class Patient : BaseModel
    {

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public int Age { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

        public ICollection<Visit> Visits { get; set; }
    }
}
