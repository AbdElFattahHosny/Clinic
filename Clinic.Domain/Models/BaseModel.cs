using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Models
{
    public class BaseModel
    {
        public long Id { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
