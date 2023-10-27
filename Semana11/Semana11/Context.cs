using Microsoft.EntityFrameworkCore;
using Semana11;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

//namespace Semana11
    public class ContextDB : DbContext
    {
        public DbSet<Student> Estudiante{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-NFDMETJ;Database=PROGRA2;Trusted_Connection = True;");
        }
    }