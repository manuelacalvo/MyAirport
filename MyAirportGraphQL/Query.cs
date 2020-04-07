using GraphQL.Types;
using MCSP.MyAirport.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAirportGraphQL
{
    public class AirportQuery: ObjectGraphType
    {
        public AirportQuery(MyAirportContext db)
        {
            Field<ListGraphType<AirportQuery>>(
                "bagages",
                resolve: context => db.Bagages.ToList());
        }
    }
}
