using BalnearioGestion.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalnearioGestion.Data
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }

        public DbSet <Cliente> Clientes { get; set; }
        public DbSet<ServicioBalneario> ServicioBalnearios { get; set; }

        public DbSet<Gastos> Gastos { get; set; }


    }
}
