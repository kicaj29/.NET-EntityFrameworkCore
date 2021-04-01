using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorUsageByEFCore
{
    public class MyDBContext : DbContext
    {
        public virtual DbSet<Person> Persons { get; set; }

        public MyDBContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            
        }
    }
}
