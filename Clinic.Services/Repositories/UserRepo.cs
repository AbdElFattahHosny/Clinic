using Clinic.Domain.Models;
using Clinic.Repo.Data;
using Clinic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Services.Repositories
{
    public class UserRepo : IUser
    {
        private readonly AppDbContext context;

        public UserRepo(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(User t)
        {
            context.Users.AddAsync(t);
        }

        public void Delete(User t)
        {
            context.Users.Remove(t);
        }

        public async void Edit(long oldId, User t)
        {
            User user = await GetById(oldId);
            user.UserName = t.UserName;
            user.RoleId = t.RoleId;
            user.Password = t.Password;
            user.ModifiedOn = DateTime.Now;
            user.ModifiedBy = t.ModifiedBy;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await context.Users.Include(x=>x.Role).ToListAsync();
        }

        public async Task<User> GetById(long id)
        {
            return await context.Users.Include(x => x.Role).FirstOrDefaultAsync(x=>x.Id==id);
        }
    }
}
