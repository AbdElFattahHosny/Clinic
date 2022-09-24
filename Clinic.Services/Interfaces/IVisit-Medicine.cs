using Clinic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Services.Interfaces
{
    public interface IVisit_Medicine
    {
        void Add(long VisitId, long MedId);
        Task<Visit_Medicine> getByIds(long VisitId, long MedId);

        Task<Visit_Medicine> getByVisitId(long VisitId);
    }
}
