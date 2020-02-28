using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace MCSP.MyAirport.EF
{
    public class MyAirportContext : DbContext
    {
        public MyAirportContext()
        {

        }
        public DbSet<Bagage> Bagages { get; set; }
        public DbSet<Vol> Vols { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(ConfigurationManager.ConnectionStrings["MyAirportDatabase"].ConnectionString);
          
        }
    }

}

