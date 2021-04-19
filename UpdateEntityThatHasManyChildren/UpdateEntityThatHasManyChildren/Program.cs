using System;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace UpdateEntityThatHasManyChildren
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new MyDbContext();
            context.Database.EnsureCreated();


            var b = context.Set<Blog>().Where(b => b.Id == 1).Include(b => b.Posts).First();

            StringBuilder sb = new StringBuilder();

            sb.Append($"Id: {b.Id}\n");
            sb.Append($"Name: {b.Name}\n");
            sb.Append("Posts:\n");

            var p = b.Posts.First();
            sb.Append($"PostId: {p.Id}");
            sb.Append($"PostName: {p.Name}");

            p.Name = "new name";

            sb.Append($"Post NEW Name: {p.Name}");
            
            /*foreach (var o in b.Opinions)
            {
                sb.Append($"OpinionId: {o.Id}");
                sb.Append($"OpinionName: {o.Name}");
            }*/

            context.Update(p);
            context.SaveChanges();

            Console.WriteLine(sb.ToString());

            Console.ReadKey();
        }
    }
}
