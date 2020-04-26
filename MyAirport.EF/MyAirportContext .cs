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

        /// <summary>
        /// Ajout Contraintes d'unicité
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bagage>().HasIndex(x => new { x.CodeIata, x.DateCreation }).IsUnique();
            modelBuilder.Entity<Vol>().HasIndex(x => new { x.Cie, x.Lig, x.Dhc }).IsUnique();
        }
        
        /* protected override void OnConfiguring(DbContextOptionsBuilder options)
          {
              //options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyAirport;Integrated Security=True");
              options.UseSqlServer(ConfigurationManager.ConnectionStrings["MyAirportDatabase"].ConnectionString);
              options.UseLoggerFactory(MyAirportLoggerFactory);
          }*/
    }

}

