using Clinic.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Repo.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Medicine> Medicines { get; set; }

        public DbSet<Visit_Medicine> Visit_Medicines { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<VisitType> VisitTypes { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }

    }
}
