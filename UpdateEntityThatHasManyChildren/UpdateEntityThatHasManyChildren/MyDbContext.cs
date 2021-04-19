using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateEntityThatHasManyChildren
{
    public class MyDbContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDB)\v11.0;Database=EFCoreDB1");            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            /*modelBuilder.Entity<Blog>().HasData(
                    new Blog()
                    {
                        Id = 1,
                        Name = "Blog1",
                        Posts = new List<Post>(new Post[] {
                                    new Post()
                                    {
                                        Id = 1,
                                        Name = "Post1"
                                    }
                                }),
                        Opinions = new List<Opinion>(new Opinion[] {
                                    new Opinion()
                                    {
                                        Id = 1,
                                        Name = "Opinion1"
                                    }
                        })
                    }
                );*/

            modelBuilder.Entity<Blog>().HasData(
                new Blog()
                {
                    Id = 1,
                    Name = "Blog1"
                }
            );

            modelBuilder.Entity<Post>().HasData(
                new Post()
                {
                    Id = 1,
                    Name = "Post1",
                    BlogId = 1
                }
            );

            modelBuilder.Entity<Opinion>().HasData(
                new Opinion()
                {
                    Id = 1,
                    Name = "Opinion1",
                    BlogId = 1
                }
            );
        }
    }
}
