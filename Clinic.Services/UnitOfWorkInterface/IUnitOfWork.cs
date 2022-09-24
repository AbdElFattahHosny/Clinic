using Clinic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Services.UnitOfWorkInterface
{
    public interface IUnitOfWork : IDisposable
    {
        IAppointment Appointment { get; }
        IMedicine Medicine { get; }

        IPatient Patient { get; }
        IRole Role { get; }
        IUser User { get; }
        IVisit Visit { get; }
        IVisit_Medicine Visit_Medicine { get; }
        IVisitType VisitType { get; }

        Task<int> Save();
        
    }
}
