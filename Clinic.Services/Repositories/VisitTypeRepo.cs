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
    public class VisitTypeRepo : IVisitType
    {
        private readonly AppDbContext context;

        public VisitTypeRepo(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(VisitType t)
        {
            context.VisitTypes.AddAsync(t);
        }

        public void Delete(VisitType t)
        {
            context.VisitTypes.Remove(t);
        }

        public async void Edit(long oldId, VisitType t)
        {
            VisitType visitType = await GetById(oldId);
            visitType.TypeName = t.TypeName;
            visitType.ModifiedBy = t.ModifiedBy;
            visitType.ModifiedOn = DateTime.Now;
        }

        public async Task<IEnumerable<VisitType>> GetAll()
        {
            return await context.VisitTypes.ToListAsync();
        }

        public async Task<VisitType> GetById(long id)
        {
            return await context.VisitTypes.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
