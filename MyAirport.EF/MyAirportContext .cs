using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Microsoft.Extensions.Logging;

namespace MCSP.MyAirport.EF
{
    /// <summary>
    /// composant MyAirportContext
    /// </summary>
    public class MyAirportContext : DbContext
    {
        /// <summary>
        /// Constructeur MyAirportContext
        /// </summary>
        public MyAirportContext(DbContextOptions<MyAirportContext> options) : base(options)
        {

        }

        /// <summary>
        /// Journalisation dans la console
        /// </summary>
        public static readonly ILoggerFactory MyAirportLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        /// <summary>
        /// Ajout Bdd Bagages
        /// </summary>
        public DbSet<Bagage> Bagages { get; set; } = null!;

        /// <summary>
        /// Ajout Bdd Vols
        /// </summary>
        public DbSet<Vol> Vols { get; set; } = null!;


      /* protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyAirport;Integrated Security=True");
            options.UseSqlServer(ConfigurationManager.ConnectionStrings["MyAirportDatabase"].ConnectionString);
            options.UseLoggerFactory(MyAirportLoggerFactory);
        }*/
    }

}

