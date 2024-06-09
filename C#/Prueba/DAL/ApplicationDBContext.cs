using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prueba.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Prueba.DAL
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Contacto> Contacto { get; set; }
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }
    }
}