using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFcoreDeletingRows
{
    public class MyDBContext : DbContext
    {
        public virtual DbSet<Root> Root { get; set; }
        public virtual DbSet<Parent> Parent { get; set; }
        public virtual DbSet<Child> Child { get; set; }

        public MyDBContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Root>(entity =>
            {
                entity.HasKey(k => new { k.Id })
                    .HasName("[PK_Root]");
            });

            modelBuilder.Entity<Parent>(entity =>
            {
                entity.HasKey(k => new {k.Id, k.RootId})
                    .HasName("[PK_Parent]");
            });

            modelBuilder.Entity<Child>(entity =>
            {
                entity.HasKey(k => new { k.Id, k.RootId })
                    .HasName("[PK_Child]");
            });
        }
    }
}
