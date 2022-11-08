using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Dev_Project.Models;

namespace Web_Dev_Project.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) :base(options)
        {

        }
        //map to tables
        public DbSet<Art> ArtTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Art>().HasData(
                new Art() { PieceName = "Owl", Description = "This piece and an owl and hour glass", Id = 1 },
                new Art() { PieceName = "Portrait", Description = "This is a portrait of a musician a client likes", Id = 2 },
                new Art() { PieceName = "Rose", Description = "This piece and a rose.", Id = 3}
                );
        }
    }
}
