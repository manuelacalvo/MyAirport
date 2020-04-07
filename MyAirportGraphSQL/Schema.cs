using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAirportGraphSQL
{
    public class AirportSchema : Schema
    {
        public AirportSchema(IDependencyResolver resolver)  : base(resolver)
        {
            Query = resolver.Resolve<AirportQuery>();
        }
    }
}
