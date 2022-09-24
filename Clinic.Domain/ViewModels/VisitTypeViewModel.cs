using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.ViewModels
{
    public class VisitTypeViewModel
    {
        [Required]
        [StringLength(20)]
        public string TypeName { get; set; }
    }
}
