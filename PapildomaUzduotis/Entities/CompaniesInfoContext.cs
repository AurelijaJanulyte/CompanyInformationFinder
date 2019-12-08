using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapildomaUzduotis.Entities
{
    public class CompaniesInfoContext:DbContext
    {
        public CompaniesInfoContext(DbContextOptions<CompaniesInfoContext> optinions)
            :base (optinions)
        {
            Database.EnsureCreated();
        }
        public DbSet<Companies> Companies { get; set; }
    }
}
