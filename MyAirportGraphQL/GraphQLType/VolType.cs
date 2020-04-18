using GraphQL.Types;
using MCSP.MyAirport.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAirportGraphQL.GraphQLType
{
    public class VolType : ObjectGraphType<Vol>
    {
        public VolType()
        {
            Field(x => x.Cie);
            Field(x => x.Des);
            Field(x => x.Dhc, nullable: true);
            Field(x => x.Imm);
            Field(x => x.Lig);
            Field<IntGraphType>("Pax", resolve: context => ((Vol)context.Source).Pax);
            Field(x => x.Pkg);
            Field(x => x.VolId);
           
        }

    }
}
