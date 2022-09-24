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
    public class Visit_MedicineRepo : IVisit_Medicine
    {
        private readonly AppDbContext context;

        public Visit_MedicineRepo(AppDbContext context)
        {
            this.context = context;
        }

        public void Add(long VisitId, long MedId)
        {

            context.Visit_Medicines.AddAsync(getByIds(VisitId,MedId).Result);
        }

        public async Task<Visit_Medicine> getByIds(long VisitId, long MedId)
        {
            return await context.Visit_Medicines
                .Include(x=>x.Medicine)
                .FirstOrDefaultAsync(x => x.VisitId == VisitId && x.MedicineId == MedId);
        }

        public Task<Visit_Medicine> getByVisitId(long VisitId)
        {
            throw new NotImplementedException();
        }
    }
}
