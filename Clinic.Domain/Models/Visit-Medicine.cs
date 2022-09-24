using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Models
{
    public class Visit_Medicine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long VisitId { get; set; }

        public Visit Visits { get; set; }

        public long MedicineId { get; set; }

        public Medicine Medicine { get; set; }

        public string Details { get; set; }
    }
}
