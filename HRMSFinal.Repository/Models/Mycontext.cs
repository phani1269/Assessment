using HRMSFinal.Repository.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSFinal.Repository.Models
{
   public class Mycontext : NextTurnDBContext
    {
        public Mycontext()
        {
        }

        public Mycontext(DbContextOptions<NextTurnDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DeptEmp> DeptEmps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DeptEmp>(x => x.HasNoKey());
        }

    }
}
