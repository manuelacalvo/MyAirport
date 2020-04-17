using GraphQL.Types;
using MCSP.MyAirport.EF;
using MyAirportGraphQL.GraphQLType;
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
            Field<ListGraphType<BagageType>>(
                "bagages",
                resolve: context => db.Bagages.ToList());
        }
    }
}
