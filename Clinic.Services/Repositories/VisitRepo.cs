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
    public class VisitRepo : IVisit
    {
        private readonly AppDbContext context;

        public VisitRepo(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(Visit t)
        {
            context.Visits.AddAsync(t);
        }

        public void Delete(Visit t)
        {
            context.Visits.Remove(t);
        }

        public async void Edit(long oldId, Visit t)
        {
            Visit visit = await GetById(oldId);
            visit.DateOfVisit = t.DateOfVisit;
            visit.Diagnostics = t.Diagnostics;
            visit.PatientId = t.PatientId;
            visit.ModifiedBy = t.ModifiedBy;
            visit.ModifiedOn = DateTime.Now;
        }

        public async Task<IEnumerable<Visit>> GetAll()
        {
            return await context.Visits.Include(x => x.Patient).ToListAsync();
        }

        public async Task<Visit> GetById(long id)
        {
            return await context.Visits.Include(x=>x.Patient).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
