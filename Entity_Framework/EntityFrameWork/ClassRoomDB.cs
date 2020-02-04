using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWork
{
public class ClassRoomDB : DbContext
    {
        public ClassRoomDB() :base()
        {
            Console.WriteLine("Constructor");
        }
        public ClassRoomDB(DbContextOptions options) : base(options)
        {
            Console.WriteLine("Constructor: {0}", options);
        }
        public ClassRoomDB(DbContextOptions<ClassRoomDB> options): base (options)
        {
            Console.WriteLine("Constructor<ClassRoomDB>: {0}", options);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            //this.Database.EnsureDeleted();
            //this.Database.EnsureCreated();
            Console.WriteLine("On Configuring: {0}", optionsBuilder.Options);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Console.WriteLine("On ModelCreatiing: {0}", modelBuilder);
        }
        public DbSet<Student> Students { get; set; }
    }
}
