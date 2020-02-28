using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Microsoft.Extensions.Logging;

namespace MCSP.MyAirport.EF
{
    public class MyAirportContext : DbContext
    {
        /*public MyAirportContext(DbContextOptions<MyAirportContext> options) : base(options)
        {

        }
        */
       // public static readonly ILoggerFactory MyAirportLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); }); 

        public DbSet<Bagage> Bagages { get; set; }
        public DbSet<Vol> Vols { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyAirport;Integrated Security=True");
            //options.UseSqlServer(ConfigurationManager.ConnectionStrings["MyAirportDatabase"].ConnectionString);
            //options.UseLoggerFactory(MyAirportLoggerFactory);
        }
    }

}

