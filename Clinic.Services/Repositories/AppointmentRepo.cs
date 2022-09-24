using Clinic.Domain.Models;
using Clinic.Repo.Data;
using Clinic.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Services.Repositories
{
    public class AppointmentRepo : IAppointment
    {
        private readonly AppDbContext context;

        public AppointmentRepo(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(Appointment t)
        {
            context.Appointments.AddAsync(t);
        }

        public void Delete(Appointment t)
        {
            context.Appointments.Remove(t);
        }

        public async void Edit(long oldId, Appointment t)
        {
            Appointment oldObject = await GetById(oldId);
            oldObject.Number = t.Number;
            oldObject.TypeId = t.TypeId;
            oldObject.PatientId = t.PatientId;
            oldObject.Date = t.Date;
            oldObject.ModifiedOn = DateTime.Now;
            oldObject.ModifiedBy = t.ModifiedBy;
        }

        public async Task<IEnumerable<Appointment>> GetAll()
        {
            return await context.Appointments
              .Include(x => x.Patient)
              .Include(x => x.Type)
              .ToListAsync();
        }

        public async Task<Appointment> GetById(long id)
        {
            return await context.Appointments
                .Include(x => x.Patient)
                .Include(x => x.Type)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
