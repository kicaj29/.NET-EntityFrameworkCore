using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;

namespace InMemoryDB
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<MyDBContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                // .ConfigureWarnings(o => o.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            using (var context = new MyDBContext(options))
            {
                var person = new Person
                {
                    Id = 123,
                    Name = "Jacek",
                    Tags = new System.Collections.Generic.List<string>(new string[] { "Tag1" })
                };

                context.Persons.Add(person);
                context.SaveChanges();
            }

            using (var context1 = new MyDBContext(options))
            {
                foreach (var p in context1.Persons)
                {
                    Console.WriteLine($"Id: {p.Id}, Name: {p.Name}");
                }
            }

            Console.WriteLine("Hello World!");
        }
    }
}
