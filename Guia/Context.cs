using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guia
{
    public class ContextDB : DbContext
    {
        public DbSet<Student> Estudiante { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-NFDMETJ\\SQLEXPRESS;Database=Progra2;Trusted_Connection=True;");

        }
    }
}
