using System;
using MCSP.MyAirport.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Configuration;
using System.Linq;

namespace MCSP.MyAirport.ConsoleApp
{
    class Program
    {

        public static readonly ILoggerFactory MyAirportLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyAirportContext>();
            optionsBuilder.UseLoggerFactory(MyAirportLoggerFactory);
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["MyAirportDatabase"].ConnectionString);
            System.Console.WriteLine("MyAirport project bonjour!!");
            using (var db = new MyAirportContext(optionsBuilder.Options)
                //var db = new MyAirportContext()
                )
            {

                //Clear db to begin
                var bag = db.Bagages;
                foreach(var b in bag)
                {
                    db.Remove(b);
                }

                
                var vol = db.Vols;
                foreach (var v in vol)
                {
                    db.Remove(v);
                }
                db.SaveChanges();


                // Create
                Console.WriteLine("Création du vol LH1232");
                Vol v1 = new Vol
                {
                    Cie = "LH",
                    Des = "BKK",
                    Dhc = Convert.ToDateTime("14/01/2020 16:45"),
                    Imm = "RZ62",
                    Lig = "1232",
                    Pkg = "R52",
                    Pax = 238
                };
                db.Add(v1);

                Console.WriteLine("Creation vol SQ333");
                Vol v2 = new Vol
                {
                    Cie = "SK",
                    Des = "CDG",
                    Dhc = Convert.ToDateTime("14/01/2020 18:20"),
                    Imm = "TG43",
                    Lig = "333",
                    Pkg = "R51",
                    Pax = 423
                };
                db.Add(v2);

                Console.WriteLine("Creation vol BKK238");
                db.Add(new Vol("LH", "1234", Convert.ToDateTime("18/03/2020 16:45"))
                {
                    Des = "BKK",
                    Imm = "RB22",
                    Pkg = "R52",
                    Pax = 238
                }
                   );
                Console.WriteLine("creation du bagage 012387364501");
                Bagage b1 = new Bagage
                {
                    Classe = "Y",
                    CodeIata = "012387364501",
                    DateCreation = Convert.ToDateTime("14/01/2020 12:52"),
                    Destination = "BEG"
                };
                db.Add(b1);

                Console.WriteLine("creation du bagage 987654321");
                Bagage b2 = new Bagage
                {
                    Classe = "Y",
                    CodeIata = "987654321",
                    DateCreation = Convert.ToDateTime("12/04/2020 17:18"),
                    Destination = "BEG"
                };
                db.Add(b2);

                Console.WriteLine("creation du bagage 0123456789");
                db.Add(new Bagage("0123456789", Convert.ToDateTime("17/03/2020 14:09"))
                {
                    Classe = "Y",
                    Destination = "BEG"
                });





                db.SaveChanges();
                Console.ReadLine();

                // ReadBagages_Vols_VolI
                Console.WriteLine("Voici la liste des vols disponibles");
                var vols = db.Vols
                    .OrderBy(v => v.Cie);
                foreach (var v in vols)
                {
                    Console.WriteLine($"Le vol {v.Cie}{v.Lig} N° {v.VolId} a destination de {v.Des} part à {v.Dhc} heure");
                }
                Console.ReadLine();

                // Update
                Console.WriteLine($"Le bagage {b1.BagageId} est modifié pour être rattaché au vol {v1.VolId} => {v1.Cie}{v1.Lig}");
                b1.VolId = v1.VolId;
                db.SaveChanges();
                v1.Bagages.ToList().ForEach(b => Console.WriteLine($"VOLID: {v1.VolId} -> bagage {b.BagageId}"));
                Console.ReadLine();

                // Update
                Console.WriteLine($"Le bagage {b1.BagageId} est modifié pour être rattaché au vol {v2.VolId} => {v2.Cie}{v2.Lig}");
                b2.VolId = v2.VolId;
                db.SaveChanges();
                v1.Bagages.ToList().ForEach(b => Console.WriteLine($"VOLID: {v2.VolId} -> bagage {b.BagageId}"));
                Console.ReadLine();

                // Delete vol et mise a null du volId dans bagage
                Console.WriteLine($"Suppression du vol {v1.VolId} => {v1.Cie}{v1.Lig}");
                db.Remove(v1);
                db.SaveChanges();
                Console.ReadLine();

                // Delete vol et delete des bagages attribués à ce vol
                Console.WriteLine($"Suppression du vol {v2.VolId} => {v2.Cie}{v2.Lig} induisant suppression du bagage {b2.BagageId} ");
                var bagages = db.Bagages.Where(b => b.VolId == v2.VolId);
                
                foreach (var b in bagages)
                {
                        
                    db.Remove(b); 
                }
                db.Remove(v2);
                db.SaveChanges();

                Console.ReadLine();


            }
        }
    }
}
