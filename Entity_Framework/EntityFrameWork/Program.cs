using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft;
using Newtonsoft.Json.Linq;

namespace EntityFrameWork
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //optionBuilder.UseSqlServer(@"Server=WLPC;Database=LWH;Integrated Security=True");
                DbContextOptionsBuilder optionBuilder = new DbContextOptionsBuilder();
                optionBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
                ClassRoomDB croom = new ClassRoomDB(optionBuilder.Options);
                Console.WriteLine("DB Name={0}", croom.Database);
                croom.Database.EnsureDeleted();
                croom.Database.EnsureCreated();
                Student ns = new Student { Id = 0, FirstName = "Lilian", LastName = "Liu", Birthdate = DateTime.Now };
                croom.Students.Add(ns);
                Console.WriteLine("add ns");
                croom.SaveChanges();


                Student ns1 = new Student { Id = 0, FirstName = "William", LastName = "Liu", Birthdate = DateTime.Now };
                croom.Students.Add(ns1);
                croom.SaveChanges();

                Console.WriteLine("Savechanges()");
                var stus = croom.Students.ToList();

                Console.WriteLine(JArray.FromObject(stus).ToString());
                Console.WriteLine("OK");
            }
            catch(Exception err)
            {
                Console.WriteLine($"Error: {err.Message}\nMessage:{err.StackTrace}");
            }
            Console.ReadLine();
        }
    }
}
