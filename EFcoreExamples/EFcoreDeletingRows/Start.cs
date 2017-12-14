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
                "Data Source=localhost;Database=TPCentralDB;Integrated Security=SSPI;MultipleActiveResultSets=True",
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

            //need to remove old children data, as EF wont do it itself:
            dbContext.Parent.Remove(child.ParentEntity);

            child.ParentEntity = null;
            child.ParentId = null;


            var r1 = dbContext.Root.First();
            var p1 = dbContext.Parent.First();
            var c1 = dbContext.Child.First();

            var s1 = dbContext.Entry(r1).State;
            var s2 = dbContext.Entry(p1).State;
            var s3 = dbContext.Entry(c1).State;

           

            dbContext.SaveChanges();
            //transaction.Commit();

            var r1After = dbContext.Root.First();
            var p1After = dbContext.Parent.First();
            var c1After = dbContext.Child.First();

            var s1After = dbContext.Entry(r1After).State; //it causes System.InvalidOperationException!!! but why???
            var s2After = dbContext.Entry(p1After).State;
            var s3After = dbContext.Entry(c1After).State;

            dbContext.SaveChanges();
            var r3 = dbContext.Root.First();

            if (dbContext.Child.Count() != 1)
            {
                throw new Exception("There was error during deleting parent.");
            }

            transaction.Commit();
        }
    }
}
