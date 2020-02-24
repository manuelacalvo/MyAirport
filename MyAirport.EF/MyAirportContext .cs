using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCSP.MyAirport.EF
{
    class MyAirportContext : DbContext
    {
        public DbSet<Bagage> Bagages { get; set; }
        public DbSet<Vol> Vols { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyAirport;Integrated Security=True");
        }
    }

}

