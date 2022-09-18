using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Models
{
    public class Appointment : BaseModel
    {
        public int Number { get; set; }

        public DateTime Date { get; set; }
        public byte TypeId { get; set; }
        public VisitType Type { get; set; }

        public long PatientId { get; set; }

        public Patient Patient { get; set; }
    }
}
