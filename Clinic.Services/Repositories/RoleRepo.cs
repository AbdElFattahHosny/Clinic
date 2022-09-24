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
    public class RoleRepo : IRole
    {
        private readonly AppDbContext context;

        public RoleRepo(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(Role t)
        {
            context.Roles.AddAsync(t);
        }

        public void Delete(Role t)
        {
            context.Roles.Remove(t);
        }

        public async void Edit(long oldId, Role t)
        {
            Role role = await GetById(oldId);
            role.Name = t.Name;
            role.ModifiedBy = t.ModifiedBy;
            role.ModifiedOn = DateTime.Now;
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            return await context.Roles.ToListAsync();
        }

        public async Task<Role> GetById(long id)
        {
            return await context.Roles.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
