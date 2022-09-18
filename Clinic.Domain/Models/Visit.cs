using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Models
{
    public class Visit : BaseModel
    {
        public long PatientId { get; set; }

        public Patient Patient { get; set; }

        public DateTime DateOfVisit { get; set; }

        public string Diagnostics { get; set; }

        public ICollection<Visit_Medicine> VisitMedicines { get; set; }

    }
}
