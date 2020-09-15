using ChinookSystem.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookSystem.DAL
{
    internal class ChinookSystemContext : DbContext
    {
        public ChinookSystemContext():base("name=ChinookDB")
        {

        }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Album> Albums { get; set; }
    }
}
