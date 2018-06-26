using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprint0Sandbox.Data
{
    public class OdsdbContext : DbContext
    {
        public OdsdbContext(DbContextOptions<OdsdbContext> options) : base(options)
        {
        }

        public DbSet<ModuleVersion> ModuleVersion { get; set; }
    }
}
