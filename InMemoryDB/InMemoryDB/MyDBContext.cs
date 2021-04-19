using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryDB
{
    public class MyDBContext : DbContext
    {
        public virtual DbSet<Person> Persons { get; set; }


        public MyDBContext(DbContextOptions<MyDBContext> options)
        : base(options)
        { }
    }
}
