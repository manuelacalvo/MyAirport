using GraphQL.Types;
using MCSP.MyAirport.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAirportGraphQL.GraphQLType
{
    public class BagageType: ObjectGraphType<Bagage>
    {
        public BagageType()
        {
            Field(x => x.BagageId);
            Field(x => x.Classe);
            Field(x => x.CodeIata);
            Field(x => x.DateCreation);
            Field(x => x.Destination);
            Field(x => x.Escale);
            Field(x => x.Prioritaire, nullable: true);    
            Field(x => x.Ssur);
            Field<StringGraphType>("Sta", resolve: context => ((Bagage)context.Source).Sta.ToString());
            Field(x => x.VolId, nullable: true);

        }
      
    }
}
