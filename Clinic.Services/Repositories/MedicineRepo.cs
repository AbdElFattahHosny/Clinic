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
    public class MedicineRepo : IMedicine
    {
        private readonly AppDbContext context;

        public MedicineRepo(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(Medicine t)
        {
            context.Medicines.AddAsync(t);
        }

        public  void Delete(Medicine t)
        {
            context.Medicines.Remove(t);
        }

        public async void Edit(long oldId, Medicine t)
        {
            Medicine medicine = await GetById(oldId);
            medicine.FullName = t.FullName;
            medicine.ModifiedOn = DateTime.Now;
            medicine.ModifiedBy = t.ModifiedBy;
        }

        public async Task<IEnumerable<Medicine>> GetAll()
        {
            return await context.Medicines.ToListAsync();
        }

        public async Task<Medicine> GetById(long id)
        {
            return await context.Medicines.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
