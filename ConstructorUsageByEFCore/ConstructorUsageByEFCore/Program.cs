using System;

namespace ConstructorUsageByEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var context = new MyDBContext();

            foreach(var p in context.Persons)
            {
                Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Second name: {p.SecondName}, Address: {p.Address}");
            }

            Console.ReadKey();

        }
    }
}
