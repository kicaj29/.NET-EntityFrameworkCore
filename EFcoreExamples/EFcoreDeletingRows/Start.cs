using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace EFcoreDeletingRows
{
    public static class Start
    {
        private static MyDBContext CreateContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyDBContext>();

            optionsBuilder.UseSqlServer(
                "Data Source=localhost;Database=testDB;Integrated Security=SSPI;MultipleActiveResultSets=True",
                options =>
                {
                    options.UseRowNumberForPaging();
                    //options.EnableRetryOnFailure();
                });

            var dbContext = new MyDBContext(optionsBuilder.Options);

            return dbContext;
        }

        private static void Init()
        {
            var dbContext = CreateContext();

            var transaction = dbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            dbContext.Root.Add(new Root()
            {
                Id = "root-1",
                Name = "RootId"
            });

            dbContext.SaveChanges();
            transaction.Commit();
            dbContext.Dispose();
        }

        public static void Run()
        {
            Init();

            var dbContext = CreateContext();

            var transaction = dbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            dbContext.Child.Add(new Child()
            {
                Id = 1,
                RootId = "root-1",
                Name = "Child1",
                ParentEntity = new Parent()
                {
                    Id = "id-1",
                    RootId = "root-1",
                    Name = "Parent1"
                }
            });

            dbContext.SaveChanges();

            var child = dbContext.Child.Find(1, "root-1");

            dbContext.Parent.Remove(child.ParentEntity);


            var r1 = dbContext.Root.First();
            var p1 = dbContext.Parent.First();
            var c1 = dbContext.Child.First();

            var s1 = dbContext.Entry(r1).State;
            var s2 = dbContext.Entry(p1).State;
            var s3 = dbContext.Entry(c1).State;



            dbContext.SaveChanges();
            // transaction.Commit();

            if (dbContext.Parent.Count() != 0)
            {
                throw new Exception("EF Core error!");
            }

            if (dbContext.Child.Count() != 0)
            {
                throw new Exception("EF Core error!");
            }


            dbContext.Child.Add(new Child()
            {
                Id = 2,
                RootId = "root-1",
                Name = "Child2",
                ParentEntity = new Parent()
                {
                    Id = "id-2",
                    RootId = "root-1",
                    Name = "Parent2"
                }
            });

            dbContext.SaveChanges();

            if (dbContext.Parent.Count() == 0)
            {
                throw new Exception("EF Core error!");
            }

            if (dbContext.Child.Count() == 0)
            {
                throw new Exception("EF Core error!");
            }

            transaction.Commit();
        }
    }
}
