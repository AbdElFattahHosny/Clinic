using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Models
{
    public class VisitType
    {
        public byte Id { get; set; }

        public string TypeName { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
