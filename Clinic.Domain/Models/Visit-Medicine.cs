using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Models
{
    public class Visit_Medicine
    {

        public long Id { get; set; }

        public long VisitId { get; set; }

        public Visit Visits { get; set; }

        public long MedicineId { get; set; }

        public Medicine Medicine { get; set; }

        public string Details { get; set; }
    }
}
