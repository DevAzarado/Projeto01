using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEVAZARADO.Models;
using Microsoft.EntityFrameworkCore;

namespace DEVAZARADO.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}