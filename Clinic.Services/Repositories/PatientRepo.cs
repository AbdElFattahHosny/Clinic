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
    public class PatientRepo : IPatient
    {
        private readonly AppDbContext context;

        public PatientRepo(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(Patient t)
        {

            context.Patients.AddAsync(t);
        }

        public void Delete(Patient t)
        {
            context.Patients.Remove(t);
        }

        public async void Edit(long oldId, Patient t)
        {
            Patient patient = await GetById(oldId);
            patient.FullName = t.FullName;
            patient.PhoneNumber = t.PhoneNumber;
            patient.Address = t.Address;
            patient.Age = t.Age;
            patient.ModifiedBy = t.ModifiedBy;
            patient.ModifiedOn = DateTime.Now;

           
        }

        public async Task<IEnumerable<Patient>> GetAll()
        {
            return await context.Patients.ToListAsync();
        }

        public async Task<Patient> GetById(long id)
        {
            return await context.Patients.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
