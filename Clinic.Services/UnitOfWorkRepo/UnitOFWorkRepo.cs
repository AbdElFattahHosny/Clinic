using Clinic.Repo.Data;
using Clinic.Services.Interfaces;
using Clinic.Services.Repositories;
using Clinic.Services.UnitOfWorkInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Services.UnitOfWorkRepo
{
    public class UnitOFWorkRepo : IUnitOfWork
    {
        private readonly AppDbContext context;

        public UnitOFWorkRepo(AppDbContext _Context)
        {
            context = _Context;
            Appointment = new AppointmentRepo(this.context);
            Medicine = new MedicineRepo(this.context);
            Patient = new PatientRepo(this.context);
            Role = new RoleRepo(this.context);
            User =  new UserRepo(this.context);
            Visit = new VisitRepo(this.context);
            Visit_Medicine = new Visit_MedicineRepo(this.context);
            VisitType = new VisitTypeRepo(this.context);
        }

        public IAppointment Appointment { get; private set; }

        public IMedicine Medicine { get; private set; }

        public IPatient Patient { get; private set; }

        public IRole Role { get; private set; }

        public IUser User { get; private set; }

        public IVisit Visit { get; private set; }

        public IVisit_Medicine Visit_Medicine { get; private set; }

        public IVisitType VisitType { get; private set; }

        public void Dispose()
        {
            context.Dispose();
        }

        public async Task<int> Save()
        {
          return await context.SaveChangesAsync();
        }
    }
}
